using System;
using System.Drawing;
using System.Windows.Forms;

namespace EditorRPG
{
    [Serializable]
    class Engine
    {
        public World Map { get; set; }
        public Engine(Control control)
        {
            Map = new World(control)
            {
                Width = 1024,
                Height = 1024
            };
        }
    }
    [Serializable]
    class World
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Bounds { get; set; }
        public Point Location { get; set; }
        public Rectangle[,] Field { get; set; }
        public Image[,] Tiles { get; set; }
        public Graphics graphics { get; set; }
        public bool isDrawGrid { get; set; } = false;
        public World(Control control)
        {
            graphics = Graphics.FromHwnd(control.Handle);
        }

        public void Draw()
        {
            Field = new Rectangle[Width / 32, Height / 32];
            Tiles = new Image[Width / 32, Height / 32];
            Bounds = new Rectangle(0, 0, Width, Height);
            graphics.Clear(Color.Black);
            for (int x = 0; x < Width / 32; x++)
            {
                for (int y = 0; y < Height / 32; y++)
                {
                    Field[x, y] = new Rectangle(x * 32, y * 32, 32, 32);
                }
            }
            for (int x = 0; x < Width / 32; x++)
            {
                for (int y = 0; y < Height / 32; y++)
                {                       
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                    if (isDrawGrid)
                        graphics.DrawRectangle(Pens.Green, Field[x, y]);
                }
            }
        }

        public void ReDraw(int m_x, int m_y, Image img)
        {
            //graphics.FillRectangle(Brushes.AliceBlue, rect);
            //graphics.DrawImage(img, rect);
            Tiles[m_x, m_y] = img;

            for (int x = 0; x < Width / 32; x++)
            {
                for (int y = 0; y < Height / 32; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                    if (isDrawGrid)
                        graphics.DrawRectangle(Pens.Green, Field[x, y]);
                }
            }
        }

        public void Update()
        {
            for (int x = 0; x < Width / 32; x++)
            {
                for (int y = 0; y < Height / 32; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                    if(isDrawGrid)
                        graphics.DrawRectangle(Pens.Green, Field[x, y]);
                }
            }
        }
    }
}
