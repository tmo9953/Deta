using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;

namespace Deta
{
    public partial class Form1 : Form
    {
        const string ver = "0.0.8.1";
        public static string envi = "native";
        const string domain = "clam.gq";
        dynamic d = null;
        public static string add_to_proj;

        public Form1()
        {
            //initialise
            InitializeComponent();
            var t = new System.Net.WebClient().DownloadString("http://" + domain + "/deta/main/ver.txt");
            if (t != ver)
            {
                //program is out of date
                System.Diagnostics.Process.Start("http://"+domain+"/deta/?v=out");
            }
            //delete stuff
            if (File.Exists(@"c.bat"))
            {
                File.Delete(@"c.bat");
            }
            try
            {
                new DirectoryInfo(@"s").Delete(true);
            }
            catch
            {

            }

        }


        private void central()
        {
            //get responce from environment
            var In = TextBox1.Text;

            var outo = "error";

            if(In.ToLower() == "update")
            {
                upgrade();
            }


            if (In.Length >= 6 && In.ToLower().Substring(0, 6) == "start ")
            {
                //change environment
                var new_env = In.Substring(6);
                var restore = d;
                d = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("Deta.addons." + new_env);
                if (d != null)//check if installed
                {
                    envi = new_env;
                    outo = "Opened " + envi;
                }
                else
                {
                    outo = "Sorry, there is no such environment installed.";
                    d = restore;
                }
            }
            else
            {
                if (envi == "native")
                {
                    if (In.Length >= 8 && In.ToLower().Substring(0, 8) == "install ")
                    {
                        //install a new package
                        var pkge = In.Substring(8);
                        if(pkge.Length >= 4 && pkge.Substring(0,4) == "http")
                        {
                            //install from external source
                            outo = "This package is from an exteranl source, it may not be safe to run";
                        }
                        else
                        {
                            //install from trusted source
                            try
                            {
                                var data = new System.Net.WebClient().DownloadString("http://" + domain + "/deta/mods/" + pkge);
                                Label4.Text = "installing...";
                                var file = new System.IO.StreamWriter(@"mod\"+ pkge +".detmod");
                                file.Write(data);
                                file.Close();
                                
                            }
                            catch
                            {
                                outo = "'" + pkge +"' dose not exist";
                            }
                            upgrade();
                        }
                    }
                    else
                    {
                        outo = Responses.get(In);
                    }
                }
                else
                {
                    //alternative environment
                    if (In.ToLower() == "exit")
                    {
                        outo = "Your app was closed";
                        envi = "native";
                    }
                    else
                    {
                        outo = d.get(In);
                    }
                }
            }
            
            env.Text = "(" + envi + ")";

            //make new line if theres too much text
            var chars = 30;
            if (outo.Length > chars)
            {
                var i = 0;
                while(outo.Substring(chars+i,1) != " ")
                {
                    i++;
                    if(outo.Length < chars+i)
                    {
                        goto A;
                    }
                }
                outo = outo.Substring(0, chars+i) + Environment.NewLine + outo.Substring(chars+i);
            }
            //display
            A:
            Label4.Text = outo;
        }


        public interface addon
        {
            string get(string input);
        }

        public void upgrade()
        {
            string s = @"s";
            if (!Directory.Exists(s))
            {
                Directory.CreateDirectory(s);
            }
            ZipFile.ExtractToDirectory(@"s.zip", s);

            add_to_proj = "";
            CopyDirectory(new DirectoryInfo(@"mod"), new DirectoryInfo(@"s\Deta\addons"));
            Console.WriteLine(add_to_proj);
            var pro = @"s\Deta\Deta.csproj";
            var r = new System.IO.StreamReader(pro);
            var t = r.ReadToEnd();
            r.Close();
            var w = new System.IO.StreamWriter(pro);
            var q = t.IndexOf("<Compile Include=\"addons");
            w.Write(t.Substring(0,q) + add_to_proj + t.Substring(q));
            w.Close();


            var b = @"c.bat";
            var file = new System.IO.StreamWriter(b);
            file.Write("@echo off \r\n C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\msbuild.exe s\\Deta.sln \r\n  xcopy /s s\\Deta\\bin\\Debug\\Deta.exe Deta.exe /Y \r\n start Deta.exe \r\n exit");
            file.Close();
            System.Diagnostics.Process.Start(b);
            this.Close();
        }

        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        #region
        private void Button1_Click(object sender, EventArgs e)
        {
            central();
        }

        private void yeet(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                central();
            }
        }
        #endregion



        static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            // Copy all files.
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName,
                    file.Name));
                add_to_proj += "<Compile Include=\"addons\\"+ file.Name + "\"/>";
            }

            // Process subdirectories.
            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                // Get destination directory.
                string destinationDir = Path.Combine(destination.FullName, dir.Name);

                // Call CopyDirectory() recursively.
                CopyDirectory(dir, new DirectoryInfo(destinationDir));
            }
        }
    }
}
