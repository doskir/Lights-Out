using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lights_Out
{
    class Light : System.Windows.Forms.Button
    {
        public bool Lit
        {
            get { return _lit; }
            set
            {
                _lit = value;
                if (_lit)
                {
                    BackColor = Color.LightGreen;
                }
                else
                {
                    BackColor = Color.DarkGreen;
                }
            }

        }

        private bool _lit;
        public int Row;
        public int Column;
        public Light(int column,int row,int height,int width,bool lit)
        {
            Left = column*height;
            Top = row*height;

            Height = height;
            Width = width;

            Row = row;
            Column = column;

            Lit = lit;
            this.Click += Light_Click;
        }

        void Light_Click(object sender, EventArgs e)
        {
            Board parent = (Board) Parent;
            parent.LightClicked(this);
        }
        public void Toggle()
        {
            Lit = !Lit;
        }
    }
}
