using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deta
{
    class simplifier
    {
        public static string run(string input)
        {
            //Remove Gramar marks

            input = input.Trim();

            input = input.Trim('?');

            input = input.Trim(',');

            input = input.Trim('.');

            input = input.Trim('!');

            var t = input.IndexOf("'");
            if (t != -1)
            {
                input = input.Substring(0, t) + input.Substring(t+1);
            }

            #region 
            //this section of the code converts all of the things on the left of the "|" to the thing on the right
            var q = new string[]
            {
                "lets|let us",
                "whats|what is",
                "thats|that is",
                "youre|you are"
            };

            foreach(string e in q)
            {
                var to = e.Substring(e.IndexOf("|") + 1);
                var from = e.Substring(0,e.IndexOf("|"));

                var w = input.IndexOf(from);
                if (w != -1)
                {
                    input = input.Substring(0, w) + to + input.Substring(w + from.Length);
                }
            }

            #endregion



            return input;
        }

    }
}
