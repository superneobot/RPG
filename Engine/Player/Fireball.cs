using System.Drawing;

namespace Engine.Player
{
    public class Fireball : Spell
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Bounds { get; set; }
        public float Speed { get; set; }
        public Fireball()
        {
            Width = 8;
            Height = 8;
        }

        public void Draw(Graphics graphics)
        {
            Bounds = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            graphics.DrawEllipse(new Pen(Color.Red), Bounds);
            //graphics.FillEllipse(Brushes.Red, Bounds);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
