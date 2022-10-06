using System.Drawing;
using System.Windows.Forms;

namespace GameRPG
{
    public partial class mainform : Form
    {
        //
        EngineRPG.Engine EngineRPG;
        Graphics g;
        public mainform()
        {
            InitializeComponent();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            Application.Idle += delegate { Invalidate(); };
            //
            Viewport.BackgroundImage = new Bitmap(1024, 1024);

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
                    Width = 120,
                    Height = 120,
                    Location = new Point(0, 0)
                },
                Player = new Engine.Player.Player(Viewport)
                {
                    Location = new Point(256, 256),
                    exp_max = 100,
                    exp_evo = 10,
                    Health = 100,
                    Mana = 100
                }
            };
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


        protected override void OnPaint(PaintEventArgs e)
        {

            EngineRPG.StartEngine(g);
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

        private void mainform_MouseDown(object sender, MouseEventArgs e)
        {
            var x = e.X / 32;
            var y = e.Y / 32;

            var sel = EngineRPG.World.Field[x, y];
            EngineRPG.World.AddBox(x, y, new Engine.Map.GameObject.Box() { Location = new Point(x, y) });
            EngineRPG.World.Update();
        }
    }
}
