using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using WindowsInput.Native;
using WindowsInput;

namespace Deta
{
    class Responses
    {
        public static string[] previous_messages = new string[20];
        public static Neural_Network.model mod = new Neural_Network.model(new int[] { 2, 4, 2 }, "test", 52);

        public static string get(string Input)
        {
            
            Input = Input.ToLower();


            if( Input == "desktop" ){
            
                InputSimulator sim = new InputSimulator();

                sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_D);

            }

            //get thing here
            Input = simplifier.run(Input);

            string Output = Conversations.get(Input, previous_messages);


            //Functions 

            //Close Deta

            if( Input == "close" ){
                //Form1.;
            }

            //Shutdown

            if( Input == "shutdown" ){

                InputSimulator sim = new InputSimulator();

                sim.Keyboard.ModifiedKeyStroke(
                new[] { VirtualKeyCode.LWIN, VirtualKeyCode.VK_X },
                new[] { VirtualKeyCode.VK_U, VirtualKeyCode.VK_U }
            );
            }
            //New Chrome Window

            if( Input == "new window" ){
                Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
            }

            //Music

            var youtube_music = "https://www.youtube.com/results?search_query=";

        if((Input.Length > 4) && Input.Substring(0,4) == "play"){
                Input = Input.Substring(5);
                { 

                    var n = new d()._get(youtube_music + Input);

                    var location = n.IndexOf("data-video-ids");

                    var Outpt = n.Substring(location + 16, 50);

                    var m = Outpt.Substring(0, Outpt.IndexOf("><") - 1);

                    Process.Start("https://www.youtube.com/watch?v=" + m);

                    System.Threading.Thread.Sleep(2000);

                    InputSimulator sim = new InputSimulator();

                    sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_D);

                }

                Output = "Ok master ^^";

            //}
            }

            //Utility 

            //Time & Date

            if( Input == "what is the date" ){
                Output = DateTime.Today.ToShortDateString();
            }

            if( Input == "how old are you" ){
                Output = "Sorry, I can't seem to find an answer to that in the database";
            }

            if( Input.IndexOf("time") != -1 ){
                Output = DateTime.Today.ToShortTimeString();
                if ( Input.IndexOf("date") != -1 ){
                    Output += DateTime.Today.ToShortDateString();
            }
            }

            if(Input.IndexOf("date") != -1 ){
                Output = DateTime.Today.ToShortDateString();
            }

            //Open Files 

            if( Input == "open calculator" ){
                Output = "Here you go, Master! ^^";
                System.Diagnostics.Process.Start(@"C:\Windows\SysWOW64\calc.exe");
            }

            //Cooking_Chef_AI

            var recipe_google = "https://www.taste.com.au/search-recipes/?q=";


            if (Input.IndexOf("how to make") != -1)
            {

                Input = Input.Substring(11);
                var n = new d()._get(recipe_google + Input);

                var index = n.IndexOf("img-responsive main-icon");

                n = n.Substring(index);

                index = n.IndexOf("href")+6;

                n = n.Substring(index);

                index = n.IndexOf("\"");

                n = n.Substring(0, index);

                Process.Start("https://www.taste.com.au/"+n);

                Output = "Here you go, Master! ^^";
            }
            //Play Anime

            var anime_play = "https://www.masterani.me/anime?search=";

            if (Input.IndexOf("play anime") != -1)
            {

                Input = Input.Substring(9);

                    var n = new d()._get(anime_play + Input);

                
                }         
            
            //End of Functions

            //neural net testing
            if(Input.Substring(0,2) == "nn")
            {
                Input = Input.Substring(2);
                
                var i1 = float.Parse(Input.Substring(0,3));
                var i2 = float.Parse(Input.Substring(3, 3));
                var o = mod.run(new float[] { i1, i2 });
                Output = o[0].ToString() + "   " + o[1].ToString();
            }

            if (Input.Substring(0, 2) == "tr")
            {
                Input = Input.Substring(2);

                var i1 = float.Parse(Input.Substring(0, 3));
                var i2 = float.Parse(Input.Substring(3, 3));
                var i3 = float.Parse(Input.Substring(6, 3));
                var i4 = float.Parse(Input.Substring(9, 3));
                mod.train(new float[] { i1, i2 }, new float[] { i3, i4 }, 100000, 0.05f);
                Output = "trained!";
            }

            //End of your stuff

            var i = 19;

            while (i > 0)
            {
                previous_messages[i] = previous_messages[i - 1];
                Console.Write(previous_messages[i] + '\r');
                i -= 1;
            }

            previous_messages[0] = Input;

            //save to log

            if (Output == "Sorry, I don't understand.") {
                StreamWriter fw;
                try
                {
                    //Pass the file path and name to the StreamWriter constructor.
                    //Indicate that Append is True, so file will not be overwritten.
                    fw = new StreamWriter(@"C:\Users\thoma\Desktop\Deta Project\detalog\logs.detalog", true);
                    fw.WriteLine(Input);
                    fw.Close();
                } catch {

                }

                try {
                    var data = Input;



                    while( data.Length > 1) {
                        var u = data;
                        if (u.Length > 15) {
                            u = u.Substring(0, 15);
                        }

                        var ty = new WebClient();


                        var w = ty.DownloadString("http://clam.gq/deta/?m=" + u);
                        if (data.Length > 15)
                        {
                            data = data.Substring(data.Length - 15);
                        }
                        else
                        {
                                data = "";
                        }
                    }

                }catch
                {
                    Output += "!";
                }
            }




            return Output;
        }

        private static string Format(object now, string v)
        {
            throw new NotImplementedException();
        }
    }
}
