using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deta
{
    public partial class Form1 : Form
    {
        const string ver = "0.0.8.1";
        public static string envi = "native";
        dynamic d = null;

        public Form1()
        {
            //initialise
            InitializeComponent();
            var t = new System.Net.WebClient().DownloadString("http://clam.gq/deta/main/ver.txt");
            if (t != ver)
            {
                //program is out of date
                System.Diagnostics.Process.Start("http://clam.gq/deta/?v=out");
            }
        }


        private void central()
        {
            //get responce from environment
            var In = TextBox1.Text;

            var outo = "error";
            if (In.Length >= 6 && In.ToLower().Substring(0, 6) == "start ")
            {
                //change environment
                var new_env = In.Substring(6);
                d = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("Deta.addons." + new_env);
                if (d != null)//check if installed
                {
                    envi = new_env;
                    outo = "Opened " + envi;
                }
                else
                {
                    outo = "Sorry, there is no such environment installed.";
                }
            }
            else
            {
                if (envi == "native")
                {
                    outo = Responses.get(In);
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
    }
}
