using Engine.Map.GameObject;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Map
{
    [Serializable]
    public class World
    {
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// World Bounds
        /// </summary>
        public Rectangle Bounds { get; set; }
        /// <summary>
        /// World Field
        /// </summary>
        public Rectangle[,] Field { get; set; }
        /// <summary>
        /// World Tiles
        /// </summary>
        public Image[,] Tiles { get; set; }
        /// <summary>
        /// Tile size
        /// </summary>
        public Point TileSize { get; set; }
        private Font Font = new Font("Tahoma", 8.0F);
        //
        public Graphics graphics { get; set; }
        public Control Control { get; set; }
        public Box[,] Boxes { get; set; }
        public World(Control control)
        {
            Control = control;
        }
        public void Draw()
        {
            graphics = Graphics.FromImage(Control.BackgroundImage);
            graphics.Clear(Color.Black);
            int width = Width / TileSize.X;
            int height = Height / TileSize.Y;
            Field = new Rectangle[width, height];
            Tiles = new Image[width, height];
            Boxes = new Box[width, height];

            Bounds = new Rectangle(0, 0, Width, Height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Field[x, y] = new Rectangle(x * TileSize.X, y * TileSize.Y, TileSize.X, TileSize.Y);
                    //graphics.DrawRectangle(new Pen(Color.FromArgb(30, 30, 30), 3), Field[x, y]);
                    //graphics.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), Field[x, y]);
                    //graphics.DrawString($"{(x + width * y) + 1}", Font, new SolidBrush(Color.FromArgb(30, 30, 30)), Field[x, y].Location.X + 5, Field[x, y].Location.Y + 8);
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y]);
                }
            }
            graphics.DrawRectangle(new Pen(Color.Black, 1), Bounds);
        }

        public void AddTile(int x, int y, Image img)
        {
            if (x > -1 && y > -1)
            {
                Tiles[x, y] = img;
            }
        }

        public void AddBox(int x, int y, Box box)
        {
            if (x > 0 && y > 0)
            {
                Boxes[x, y] = box;
            }
        }

        public void Update()
        {
            for (int x = 0; x < Width / TileSize.X; x++)
            {
                for (int y = 0; y < Height / TileSize.Y; y++)
                {
                    if (Tiles[x, y] != null)
                        graphics.DrawImage(Tiles[x, y], Field[x, y].Location.X, Field[x, y].Location.Y);
                    if (Boxes[x, y] != null)
                        graphics.DrawImage(Boxes[x, y].Texture, Field[x, y]);
                }
            }
        }
    }
}
