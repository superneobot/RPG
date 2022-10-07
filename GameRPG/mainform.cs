using System.Drawing;
using System.Windows.Forms;

namespace GameRPG
{
    public partial class mainform : Form
    {
        //
        EngineRPG.Engine EngineRPG;
        Graphics graphics;
        private Rectangle selected_rect;

        public mainform()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Application.Idle += delegate { Invalidate(); };
            //
            Viewport.BackgroundImage = new Bitmap(1024, 1024);
            graphics = Graphics.FromImage(Viewport.BackgroundImage);
            EngineRPG = new EngineRPG.Engine()
            {
                World = new Engine.Map.World(Viewport)
                {
                    Width = 1024,
                    Height = 1024,
                    Bounds = new Rectangle(0, 0, Width, Height),
                    TileSize = new Point(32, 32)
                },
                MiniMap = new Engine.Map.MiniMap(Viewport)
                {
                    Width = 128,
                    Height = 128,
                    Location = new Point(0, 0),
                    miniTileSize = new Point(8, 8)
                },
                Player = new Engine.Player.Player(Viewport)
                {
                    Location = new Point(256, 256),
                    exp_max = 100,
                    exp_evo = 10,
                    Health = 100,
                    Mana = 100,
                    Speed = 4
                },
                //Fireball = new Engine.Player.Fireball()
                //{
                //    Width = 16,
                //    Height = 16,
                //    Speed = 32.0F,

                //}
            };
            // EngineRPG.Fireball.Position = new Point(EngineRPG.Player.Location.X, EngineRPG.Player.Location.Y);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        public Rectangle BBox;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                EngineRPG.MoveRight();
            }
            if (e.KeyCode == Keys.A)
            {
                EngineRPG.MoveLeft();
            }
            if (e.KeyCode == Keys.W)
            {
                EngineRPG.MoveUp();
            }
            if (e.KeyCode == Keys.S)
            {
                EngineRPG.MoveDown();
            }

            if (e.KeyCode == Keys.Space)
            {
                EngineRPG.Cast();
                EngineRPG.Fireball.Draw(graphics);

            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
                EngineRPG.Stop();
            if (e.KeyCode == Keys.A)
                EngineRPG.Stop();
            if (e.KeyCode == Keys.W)
                EngineRPG.Stop();
            if (e.KeyCode == Keys.S)
                EngineRPG.Stop();
            base.OnKeyUp(e);
        }

        private void Viewport_MouseDown(object sender, MouseEventArgs e)
        {
            var x = e.X / 32;
            var y = e.Y / 32;

            selected_rect = EngineRPG.World.Field[x, y];
            EngineRPG.World.AddBox(x, y, selected_rect);

            Text = $"{selected_rect}";
        }

        private void Viewport_Paint(object sender, PaintEventArgs e)
        {
            EngineRPG.StartEngine();
            if (EngineRPG.Fireball != null)
                EngineRPG.Fireball.Draw(graphics);
        }

        private void Viewport_MouseMove(object sender, MouseEventArgs e)
        {
            var x = e.X / 32;
            var y = e.Y / 32;

            Text = $"{x} x {y}";
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // Text = $"{EngineRPG.Fireball.Position}";
        }
    }
}
