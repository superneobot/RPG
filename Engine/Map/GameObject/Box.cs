using System;
using System.Drawing;

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

        public Box(int width, int height, Point location, Rectangle bounds)
        {
            Width = width;
            Height = height;
            Location = location;
            Bounds = bounds;
            Texture = new Bitmap("Data/box.gif");
        }

        public void Draw(Graphics g)
        {
            if (Texture == null)
            {
                g.DrawRectangle(new Pen(Color.Red), Bounds);
                g.DrawLine(new Pen(Color.Red), new Point(Bounds.Location.X, Bounds.Location.Y), new Point(Bounds.Location.X + Width, Bounds.Location.Y + Height));
                g.DrawLine(new Pen(Color.Red), new Point(Bounds.Location.X, Bounds.Location.Y + Height), new Point(Bounds.Location.X + Width, Bounds.Location.Y));
            }
            else
            {
                g.DrawImage(Texture, Bounds);
            }
        }
    }
}
