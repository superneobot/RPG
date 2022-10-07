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
            control.BackgroundImage = new Bitmap(1024, 1024);
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
        public Rectangle[,] Boxes { get; set; }
        public Graphics graphics { get; set; }
        public bool isDrawGrid { get; set; } = false;
        public World(Control control)
        {
            graphics = Graphics.FromImage(control.BackgroundImage);
        }

        public void Draw()
        {
            Field = new Rectangle[Width / 32, Height / 32];
            Tiles = new Image[Width / 32, Height / 32];
            Bounds = new Rectangle(0, 0, Width, Height);
            Boxes = new Rectangle[Width / 32, Height / 32];
            graphics.Clear(Color.Black);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
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
                    }
                }
            }
            catch { }
        }

        public void ReDraw(int m_x, int m_y, Image img)
        {
            try
            {
                Tiles[m_x, m_y] = img;
                for (int x = 0; x < Width / 32; x++)
                {
                    for (int y = 0; y < Height / 32; y++)
                    {
                        if (Tiles[x, y] != null)
                            graphics.DrawImage(Tiles[x, y], Field[x, y]);
                        if (isDrawGrid)
                            graphics.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), Field[x, y]);
                    }
                }
            }
            catch { }
        }

        public void AddBoxes(int m_x, int m_y, Rectangle box)
        {

            try
            {
                Boxes[m_x, m_y] = box;
                for (int x = 0; x < Width / 32; x++)
                {
                    for (int y = 0; y < Height / 32; y++)
                    {
                        if (Boxes[x, y] != null)
                        {
                            graphics.DrawRectangle(new Pen(Color.Black), Boxes[x, y]);
                            graphics.DrawLine(
                                new Pen(Color.Black),
                                new Point(Boxes[x, y].Location.X, Boxes[x, y].Location.Y),
                                new Point(Boxes[x, y].Location.X + Boxes[x, y].Width, Boxes[x, y].Location.Y + Boxes[x, y].Height)
                                );
                            graphics.DrawLine(
                                new Pen(Color.Black),
                                new Point(Boxes[x, y].Location.X, Boxes[x, y].Location.Y + Boxes[x, y].Height),
                                new Point(Boxes[x, y].Location.X + Boxes[x, y].Width, Boxes[x, y].Location.Y)
                                );
                        }
                    }
                }
            }
            catch { }
        }

        public void Update()
        {
            try
            {
                for (int x = 0; x < Width / 32; x++)
                {
                    for (int y = 0; y < Height / 32; y++)
                    {
                        if (Tiles[x, y] != null)
                            graphics.DrawImage(Tiles[x, y], Field[x, y]);
                        if (isDrawGrid)
                            graphics.DrawRectangle(new Pen(Color.FromArgb(20, 20, 20)), Field[x, y]);
                        if (Boxes[x, y] != null)
                        {
                            graphics.DrawRectangle(new Pen(Color.Black), Boxes[x, y]);
                            graphics.DrawLine(
                                new Pen(Color.Black),
                                new Point(Boxes[x, y].Location.X, Boxes[x, y].Location.Y),
                                new Point(Boxes[x, y].Location.X + Boxes[x, y].Width, Boxes[x, y].Location.Y + Boxes[x, y].Height)
                                );
                            graphics.DrawLine(
                                new Pen(Color.Black),
                                new Point(Boxes[x, y].Location.X, Boxes[x, y].Location.Y + Boxes[x, y].Height),
                                new Point(Boxes[x, y].Location.X + Boxes[x, y].Width, Boxes[x, y].Location.Y)
                                );
                        }
                    }
                }
            }
            catch { }
        }
    }
}
