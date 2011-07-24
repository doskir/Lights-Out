using System;
using System.Drawing;

namespace Lights_Out
{
    class Board : System.Windows.Forms.Panel
    {
        public int Rows;
        public int Columns;
        public bool _playing;
        public void Initialize(int rows,int columns)
        {
            _playing = false;
            Rows = rows;
            Columns = columns;
            foreach (Light light in Lights)
                Controls.Remove(light);
            Lights = MakeLights(rows, columns);
            //randomize the board
            Random rand = new Random();
            for(int i = 0;i <= 100;i++)
            {
                int row = rand.Next(0, rows);
                int column = rand.Next(0, columns);
                LightClicked(Lights[row, column]);
            }
            _playing = true;

        }

        internal Light[,] Lights = new Light[5,5];
        public bool Solved
        {
            get
            {
                if (!_playing)
                    return false;
                foreach (Light light in Lights)
                    if (light.Lit)
                        return false;
                return true;
            }
        }
        private Light[,] MakeLights(int rows, int columns)
        {
            var lights = new Light[rows,columns];
            int heightPerLight = Height / rows;
            int widthPerLight = Width / columns;
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    var light = new Light(row, column, heightPerLight, widthPerLight,
                                          false);
                    lights[row, column] = light;
                    Controls.Add(light);
                }
            return lights;
        }
        public void LightClicked(Light light)
        {
            if (!Solved)
            {
                light.Toggle();
                //neighbours
                
                //above
                if (light.Row > 0)
                    Lights[light.Row - 1, light.Column].Toggle();
                //below
                if (light.Row < Rows - 1)
                    Lights[light.Row + 1, light.Column].Toggle();
                //left
                if (light.Column > 0)
                    Lights[light.Row, light.Column - 1].Toggle();
                //right
                if (light.Column < Columns - 1)
                    Lights[light.Row, light.Column + 1].Toggle();
            }
        }

    }
}
