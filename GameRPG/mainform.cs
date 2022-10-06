using System.Drawing;
using System.Windows.Forms;

namespace GameRPG
{
    public partial class mainform : Form
    {
        //
        EngineRPG.Engine EngineRPG;
        Timer Updater;
        public mainform()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Application.Idle += delegate { Invalidate(); };
            //
            EngineRPG = new EngineRPG.Engine(this)
            {
                World = new Engine.Map.World(this)
                {
                    Width = 1024,
                    Height = 1024,
                    Bounds = new Rectangle(0, 0, Width, Height),
                    TileSize = new Point(32, 32)
                },
                MiniMap = new Engine.Map.MiniMap()
                {
                    Width = 200,
                    Height = 200,
                    Location = new Point(0, 0)
                },
                Player = new Engine.Player.Player()
                {
                    Location = new Point(256, 256),
                    exp_max = 100,
                    exp_evo = 10,
                    Health = 100,
                    Mana = 100
                }
            };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            EngineRPG.StartEngine(e.Graphics);
            base.OnPaint(e);
        }

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
                EngineRPG.Player.Expirience += 10;
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
    }
}
