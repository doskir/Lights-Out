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
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            NewGame();
        }
        public void NewGame()
        {
            board1.Initialize(5,5);
            winLabel.Text = "";
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (board1.Solved)
            {
                winLabel.Text = "YOU WIN!";
                timer.Stop();
                timer.Dispose();
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }


    }
}
