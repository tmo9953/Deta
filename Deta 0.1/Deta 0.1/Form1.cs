using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deta_0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void central()
        {
            var outo = responces.get(TextBox1.Text);
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
