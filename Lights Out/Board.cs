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
            var lights = new Light[5, 5];
            int heightPerLight = Height / rows;
            int widthPerLight = Width / columns;
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    //TODO: Make some lights lit by default (probability?)
                    var light = new Light(row, column, heightPerLight, widthPerLight,
                                            false);
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
