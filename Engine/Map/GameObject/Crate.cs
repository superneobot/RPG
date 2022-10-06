using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Map.GameObject
{
    [Serializable]
    public class Crate
    {
        public int Width { get; set; } = 32;
        public int Height { get; set; } = 32;
        public Rectangle Bounds { get; set; }
        public Point Location { get; set; }
        public Image Texture { get; set; }
        Control Control;

        public Crate()
        {
            //Control = control;
            //Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            //Texture = new Bitmap("Data/box.gif");
            //Draw(control.CreateGraphics());
        }

        public void Draw(Graphics g)
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            //g.DrawRectangle(new Pen(Color.Red), Bounds);
            //g.FillRectangle(Brushes.Red, Bounds);
            g.DrawImage(Texture, Bounds);
        }
    }
}
