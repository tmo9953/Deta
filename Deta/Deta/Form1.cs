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


        public Form1()
        {
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
            var outo = Responses.get(TextBox1.Text);
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
            A:
            Label4.Text = outo;
        }


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
    }
}
