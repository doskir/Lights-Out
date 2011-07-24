using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lights_Out
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            NewGame();
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (board1.Solved)
                winLabel.Text = "YOU WIN!";
        }
        public void NewGame()
        {
            board1.Initialize(5,5);
            winLabel.Text = "";
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }


    }
}
