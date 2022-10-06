using System.Drawing;
using System.Windows.Forms;

namespace Engine.Player
{
    public class Player : Model
    {
        public Point Location { get; set; }
        public string Type { get; } = "Player";
        public string Name { get; set; }
        #region Stat
        //
        public int Speed { get; set; } = 32;
        private int maxHealth = 100;
        public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
        private int health = 100;
        public int Health { get { return health; } set { health = value; } }
        private int maxMana = 100;
        private int minMana = 0;
        public int MaxMana { get { return maxMana; } set { maxMana = value; } }
        private int mana = 100;
        public int Mana { get { return mana; } set { if (value < minMana) value = 0; else mana = value; } }
        private int level = 1;
        public int Level { get { return level; } set { level = value; } }
        public int exp_max = 10;
        public int exp_evo = 1;
        private int exp = 0;
        private int power = 1;
        public int Power { get { return power; } set { power = value; } }
        public Color Color { get; set; }
        public Image Icon { get; set; } = null;
        public Image Hero { get; set; } = null;
        public int Expirience
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
                if (exp > exp_max)
                {
                    Level++;
                    power++;
                    maxHealth += 5;
                    maxMana += 10;
                    Mana = maxMana;
                    exp = 0;
                    exp_max += exp_evo;
                }
            }
        }
        //
        #endregion
        Font Font = new Font("Motiva Sans", 8.0F);
        Graphics graphics { get; set; }
        public Player(Control control)
        {
            graphics = Graphics.FromImage(control.BackgroundImage);
            Width = 32;
            Height = 32;
            Location = new Point(256, 256);
            Speed = 2;
            Hero = new Bitmap("Data/Player/Down/frame_1.gif");
        }


        public void Draw()
        {
            Bounds = new Rectangle(Location.X, Location.Y, Width, Height);
            if (Hero != null)
            {
                graphics.DrawImage(Hero, Bounds);
            }
            else
            {
                graphics.DrawRectangle(new Pen(Color.Red), Bounds);
                graphics.DrawString(Type, Font, new SolidBrush(Color.Red), Bounds.Location.X - 1, Bounds.Location.Y - 10);
                graphics.DrawLine(new Pen(Color.Red), new Point(Bounds.Location.X, Bounds.Location.Y), new Point(Bounds.Location.X + Width, Bounds.Location.Y + Height));
                graphics.DrawLine(new Pen(Color.Red), new Point(Bounds.Location.X, Bounds.Location.Y + Height), new Point(Bounds.Location.X + Width, Bounds.Location.Y));
            }
        }

        public void DrawStats(float pos_x, float pos_y)
        {
            Font font = new Font("Motiva Sans", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush panel_stats_color = new SolidBrush(Color.FromArgb(10, 10, 10));
            //Stats bar
            graphics.FillRectangle(panel_stats_color, pos_x, pos_y, 200, 70);
            //Player icon             
            if (Icon != null)
            {
                Rectangle rect = new Rectangle((int)(pos_x + 5), (int)(pos_y + 5), 32, 32);
                graphics.DrawImage(Icon, rect);
            }
            else
            {
                graphics.DrawRectangle(new Pen(Color.Silver), pos_x + 5, pos_y + 5, 40, 40);
            }
            //Player name
            graphics.DrawString(Name, font, Brushes.Silver, pos_x + 50, pos_y + 3);

            //Player health
            #region Health bar
            //DrawBar(g, new Rectangle((int)pos_x + 50, (int)pos_y + 18, 100, 10), Color.Red);
            graphics.DrawRectangle(new Pen(Color.Red), (int)pos_x + 50, (int)pos_y + 18, 100, 10);
            graphics.FillRectangle(Brushes.Pink, (int)pos_x + 50, (int)pos_y + 18, 100, 10);
            Rectangle rect_health = new Rectangle((int)pos_x + 50, (int)pos_y + 18, 100, 10);
            Rectangle healthProgress = new Rectangle(
                rect_health.X,
                rect_health.Y,
                CalculateProgressRectSize(rect_health, maxHealth, health),
                rect_health.Height);
            DrawHealthBar(graphics, healthProgress);
            //g.DrawString($"{Health}", font, Brushes.Red, pos_x + 150, pos_y + 17);
            #endregion

            //Player mana
            #region Mana bar
            //DrawBar(g, new Rectangle((int)pos_x + 49, (int)pos_y + 30, 100, 10), Color.Blue);
            graphics.DrawRectangle(new Pen(Color.Blue), (int)pos_x + 50, (int)pos_y + 30, 100, 10);
            graphics.FillRectangle(Brushes.AliceBlue, (int)pos_x + 50, (int)pos_y + 30, 100, 10);
            Rectangle rect_mana = new Rectangle((int)pos_x + 50, (int)pos_y + 30, 100, 10);
            Rectangle manaProgress = new Rectangle(
                rect_mana.X,
                rect_mana.Y,
                CalculateProgressRectSize(rect_mana, maxMana, mana),
                rect_mana.Height);
            DrawManaBar(graphics, manaProgress);
            #endregion

            graphics.DrawString($"{Health}", font, Brushes.Red, pos_x + 153, pos_y + 17);
            graphics.DrawString($"{Mana}", font, Brushes.Blue, pos_x + 153, pos_y + 30);

            //Player level
            graphics.DrawString($"Level: {Level}", font, Brushes.Gold, pos_x + 50, pos_y + 50);
            //Player exp
            graphics.DrawString($"Exp: {Expirience}", font, new SolidBrush(Color.Gold), pos_x + 110, pos_y + 50);

            //exp bar
            #region Expirience bar
            graphics.DrawRectangle(new Pen(Color.FromArgb(61, 207, 10)), pos_x, pos_y + 70, 200, 10);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 254, 194)), pos_x, pos_y + 70, 200, 10);
            Rectangle rect_exp = new Rectangle((int)pos_x, (int)pos_y + 70, 200, 10);
            Rectangle expProgress = new Rectangle(
                rect_exp.X,
                rect_exp.Y,
                CalculateProgressRectSize(rect_exp, exp_max, exp),
                rect_exp.Height);
            DrawExpProgress(graphics, expProgress);
            #endregion
        }

        private void DrawExpProgress(Graphics g, Rectangle rect)
        {
            if (rect.Width > 0)
            {
                g.DrawRectangle(new Pen(Color.FromArgb(61, 207, 10)), rect);
                g.FillRectangle(new SolidBrush(Color.FromArgb(61, 207, 10)), rect);
            }
        }

        private void DrawHealthBar(Graphics g, Rectangle rect)
        {
            if (rect.Width > 0)
            {
                g.DrawRectangle(new Pen(Color.Red), rect);
                g.FillRectangle(new SolidBrush(Color.Red), rect);
            }
        }

        private void DrawManaBar(Graphics g, Rectangle rect)
        {
            if (rect.Width > 0)
            {
                g.DrawRectangle(new Pen(Color.Blue), rect);
                g.FillRectangle(new SolidBrush(Color.Blue), rect);
            }
        }

        private int CalculateProgressRectSize(Rectangle rect, int max, int value)
        {
            int margin = max - 0;
            return rect.Width * value / margin;
        }
    }
}
