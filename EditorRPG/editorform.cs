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
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Application.Idle += delegate { Invalidate(); };
            Engine = new Engine(Viewport);
            Texture = new Bitmap(32, 32);


            Updater = new Timer();
            Updater.Interval = 10;
            Updater.Tick += Updater_Tick;
        }

        private void Updater_Tick(object sender, System.EventArgs e)
        {
            m_size.Text = $"Map Size: {Engine.Map.Bounds.Width} x {Engine.Map.Bounds.Height}";
        }

        private void Viewport_Paint(object sender, PaintEventArgs e)
        {
            Engine.Map.Draw();
        }

        private void editorform_Load(object sender, System.EventArgs e)
        {
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
        }

        private void ControlPanel_Click(object sender, System.EventArgs e)
        {
            Texture = null;
        }

        private void box_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/box.gif");
        }

        private void save_btn_Click(object sender, System.EventArgs e)
        {
            string path = "Data/map.gamemap";
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, Engine.Map.Tiles);
            }
        }

        private void load_btn_Click(object sender, System.EventArgs e)
        {
            string path = "Data/map.gamemap";
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Engine.Map.Tiles = (Image[,])formatter.Deserialize(fs);
            }

            Engine.Map.Update();
        }

        private void grass_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/grass.jpg");
        }

        private void bottom_grass_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/bottom_grass.jpg");
        }

        private void earth_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/earth.gif");
        }

        private void brick_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/brick.gif");
        }

        private void road_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/road.gif");
        }

        private void Viewport_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void top_grass_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/top_grass.jpg");
        }

        private void draw_grid_bool_Click(object sender, System.EventArgs e)
        {
            if (!Engine.Map.isDrawGrid)
            {
                Engine.Map.isDrawGrid = true;
                draw_grid_bool.Checked = true;
            }
            else
            {
                Engine.Map.isDrawGrid = false;
                draw_grid_bool.Checked = false;
            }
        }
    }
}
