using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Engine.Map.GameObject
{
    [Serializable]
    public class Box
    {
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;
        public Rectangle Bounds { get; set; }
        public Point Location { get; set; }
        public Image Texture { get; set; }

        public Box()
        {
            Width = 32;
            Height = 32;
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            var tex = new Bitmap(32, 32, PixelFormat.Format32bppRgb);
            Texture = Image.FromFile("Data/box.gif");
            Graphics g = Graphics.FromImage(tex);
            g.DrawImage(Texture, Bounds);
            //Draw(g);
        }

        public void Draw(Graphics g)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            g.DrawRectangle(new Pen(Color.Red), Bounds);
        }
    }
}
