using System.Drawing;
using System.Windows.Forms;

namespace Engine.Map
{
    public class MiniMap
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Bounds { get; set; }
        public Point Location { get; set; }
        Graphics graphics { get; set; }
        public MiniMap(Control control) { graphics = Graphics.FromImage(control.BackgroundImage); }
        public void Draw(Player.Player player, World map)
        {
            Bounds = new Rectangle(Location.X + 1, Location.Y + 16, Width, Height);
            graphics.FillRectangle(new SolidBrush(Color.Silver), Location.X + 1, Location.Y, Width, 13);
            graphics.DrawRectangle(new Pen(Color.Silver, 3), Location.X + 1, Location.Y, Width, 13);
            graphics.DrawString($"Stage: {0}", new Font("Motiva Sans", 10.0F, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.Black, new PointF(Location.X, Location.Y + 1));
            graphics.DrawRectangle(new Pen(Color.Silver, 3), Bounds);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(10, 10, 10)), Bounds);

            var posx = (player.Location.X * Width) / (map.Width);
            var posy = (player.Location.Y * Height) / (map.Width);
            DrawPlayerOnMap((int)posx, (int)posy);
        }

        private void DrawPlayerOnMap(int posx, int posy)
        {
            var playerOnMap = new Rectangle(Location.X + posx + 1, Location.Y + posy + 15, 4, 4);
            graphics.FillRectangle(Brushes.Red, playerOnMap);
        }
    }
}
