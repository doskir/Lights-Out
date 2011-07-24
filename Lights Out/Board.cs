using System;
using System.Drawing;

namespace Lights_Out
{
    class Board : System.Windows.Forms.Panel
    {
        public void Initialize(int rows,int columns)
        {
            Lights = MakeLights(rows, columns);
            
        }
        internal Light[,] Lights;
        private Light[,] MakeLights(int rows, int columns)
        {
            Random rand = new Random();
            var lights = new Light[5, 5];
            int heightPerLight = Height / rows;
            int widthPerLight = Width / columns;
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    bool lit = rand.NextDouble() >= 0.5;
                    var light = new Light(row, column, heightPerLight, widthPerLight,
                                          lit);
                    lights[row, column] = light;
                    Controls.Add(light);
                }
            return lights;
        }
        public void LightClicked(Light light)
        {
            light.Toggle();
        }

    }
}
