using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace EditorRPG
{
    public partial class editorform : Form
    {
        Engine Engine;
        Timer Updater;
        public Image Texture;
        private Rectangle selected_rect;
        bool isPressed = false;
        public editorform()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Application.Idle += delegate { Viewport.Invalidate(); };
            Engine = new Engine(Viewport);
            Texture = new Bitmap(32, 32);


            Updater = new Timer();
            Updater.Interval = 10;
            Updater.Tick += Updater_Tick;


        }
        private void Clear()
        {
            for (int x = 0; x < Engine.Map.Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Engine.Map.Tiles.GetLength(1); y++)
                {
                    Engine.Map.Tiles[x, y] = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    Graphics g = Graphics.FromImage(Engine.Map.Tiles[x, y]);
                    var unit = GraphicsUnit.Point;
                    g.FillRectangle(Brushes.Black, Texture.GetBounds(ref unit));
                }
            }
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

        private void Updater_Tick(object sender, System.EventArgs e)
        {
            m_size.Text = $"Map Size: {Engine.Map.Bounds.Width} x {Engine.Map.Bounds.Height}";
        }

        private void Viewport_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void editorform_Load(object sender, System.EventArgs e)
        {

            Engine.Map.Draw();
            Updater.Start();
        }

        private void Viewport_MouseDown(object sender, MouseEventArgs e)
        {
            int mouse_x = e.X / 32;
            int mouse_y = e.Y / 32;
            isPressed = true;
            selected_rect = Engine.Map.Field[mouse_x, mouse_y];
            Engine.Map.ReDraw(mouse_x, mouse_y, Texture);
        }

        private void Viewport_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / 32;
            int y = e.Y / 32;
            mouse_pos.Text = $"Mouse pos: {x} x {y}";
            if (isPressed)
            {
                Engine.Map.ReDraw(x, y, Texture);
            }
            //var rect = Engine.Map.Field[x, y];
            //var img = Engine.Map.Tiles[x, y];
            //if (img != null)
            //{
            //    var nimg = new Bitmap(32, 32);
            //    Graphics g = Graphics.FromImage(nimg);
            //    var unit = GraphicsUnit.Point;
            //    g.FillRectangle(new SolidBrush(Color.Red), nimg.GetBounds(ref unit));
            //}
        }

        private void ControlPanel_Click(object sender, System.EventArgs e)
        {

        }

        private void save_btn_Click(object sender, System.EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Title = "Сохранить карту";
                save.Filter = "RPG Game map file|*.gamemap";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string path = save.FileName;
                    IFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        formatter.Serialize(fs, Engine.Map.Tiles);
                    }
                }
            }
        }

        private void load_btn_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Загрузить карту";
                open.Filter = "RPG Game map file|*.gamemap";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string path = open.FileName;
                    IFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        Engine.Map.Tiles = (Image[,])formatter.Deserialize(fs);
                    }
                }
            }
            Engine.Map.Update();
        }
        private void box_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/box.gif");
            Texture.Tag = "Box";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void grass_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/grass.jpg");
            Texture.Tag = "Grass";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void bottom_grass_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/bottom_grass.jpg");
            Texture.Tag = "Bottom grass";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void earth_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/earth.gif");
            Texture.Tag = "Earth";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void brick_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/brick.gif");
            Texture.Tag = "Brick";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void road_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/road.gif", true);
            Texture.Tag = "Road";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void top_grass_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/top_grass.jpg");
            Texture.Tag = "Top grass";
            Text = $"Editor RPG - [{Texture.Tag}]";
        }


        private void Viewport_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }
        private void draw_grid_bool_Click(object sender, System.EventArgs e)
        {
            if (!Engine.Map.isDrawGrid)
            {
                Engine.Map.isDrawGrid = true;
                draw_grid_bool.Checked = true;
                Engine.Map.Update();
            }
            else
            {
                Engine.Map.isDrawGrid = false;
                draw_grid_bool.Checked = false;
                Viewport.Invalidate();
            }
        }

        private void clear_btn_Click(object sender, System.EventArgs e)
        {
            for (int x = 0; x < Engine.Map.Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Engine.Map.Tiles.GetLength(1); y++)
                {
                    var a = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    Engine.Map.Tiles[x, y] = a;
                    Graphics g = Graphics.FromImage(Engine.Map.Tiles[x, y]);
                    var unit = GraphicsUnit.Point;
                    g.FillRectangle(Brushes.Black, a.GetBounds(ref unit));
                }
            }
        }

        private void cleared_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Texture.Tag = "Empty";
            Graphics g = Graphics.FromImage(Texture);
            var unit = GraphicsUnit.Point;
            g.FillRectangle(Brushes.Black, Texture.GetBounds(ref unit));
            Text = $"Editor RPG - [{Texture.Tag}]";
        }

        private void draw_grid_bool_CheckedChanged(object sender, System.EventArgs e)
        {

        }
    }
}
