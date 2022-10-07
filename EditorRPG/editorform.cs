using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace EditorRPG
{
    public enum State
    {
        Texture,
        Object
    }

    public partial class editorform : Form
    {
        State state;
        Engine Engine;
        Timer Updater;
        public Image Texture;
        private Rectangle selected_rect;
        bool isPressed = false;
        public Bitmap Screenshot;
        private Image temp;

        public editorform()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Application.Idle += delegate { Viewport.Invalidate(); };
            state = State.Texture;
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
            if (e.Button == MouseButtons.Left)
            {
                if (state == State.Texture)
                {
                    Engine.Map.ReDraw(mouse_x, mouse_y, Texture);
                }
                else if (state == State.Object)
                {
                    Engine.Map.AddBoxes(mouse_x, mouse_y, selected_rect);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (state == State.Texture)
                {
                    var bmp = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    Engine.Map.ReDraw(mouse_x, mouse_y, bmp);
                    var item = Engine.Map.Tiles[mouse_x, mouse_y];
                }
                else if (state == State.Object)
                {
                    var list = Engine.Map.Boxes[mouse_x, mouse_y];
                    Engine.Map.Boxes[mouse_x, mouse_y] = new Rectangle(0, 0, 0, 0);
                }
            }
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
                    CreateMiniMap(save);
                    IFormatter formatter = new BinaryFormatter();
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        formatter.Serialize(fs, Engine.Map.Tiles);
                        formatter.Serialize(fs, Engine.Map.Boxes);
                        formatter.Serialize(fs, temp);
                    }
                }
            }
        }

        private void CreateMiniMap(SaveFileDialog save)
        {
            Screenshot = new Bitmap(Viewport.Width, Viewport.Height);
            Viewport.DrawToBitmap(Screenshot, Viewport.ClientRectangle);
            //var temp = new Bitmap(Viewport.Width, Viewport.Height);
            Screenshot.Save(save.FileName + ".bmp");
            var image = Image.FromFile("temp.bmp");
            temp = ScaleImage(image, 128, 128);
            temp.Save(save.FileName + "_mini.bmp");
            File.Delete(save.FileName + ".bmp");
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
                        Engine.Map.Boxes = (Rectangle[,])new BinaryFormatter().Deserialize(fs);
                        temp = (Image)new BinaryFormatter().Deserialize(fs);
                    }
                }
            }
            Engine.Map.Update();
        }

        private Image ScaleImage(Image source, int width, int height)
        {

            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height);  // Очищаем экран
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight)  // Исходное изображение меньше целевого
                {
                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);
                }
                else if (srcwidth / srcheight > dstwidth / dstheight)  // Пропорции исходного изображения более широкие
                {
                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);
                }
                else  // Пропорции исходного изображения более узкие
                {
                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);
                }

                return dest;
            }
        }

        private void box_Click(object sender, System.EventArgs e)
        {
            //Texture = new Bitmap("Data/Textures/box.gif");
            //Texture.Tag = "Box";
            //state = State.Texture;
            //Text = $"Editor RPG - [{Texture.Tag}]";

            state = State.Object;
        }
        private void grass_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/grass.jpg");
            Texture.Tag = "Grass";
            state = State.Texture;
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void bottom_grass_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/bottom_grass.jpg");
            Texture.Tag = "Bottom grass";
            state = State.Texture;
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void earth_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/earth.gif");
            Texture.Tag = "Earth";
            state = State.Texture;
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void brick_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/brick.gif");
            Texture.Tag = "Brick";
            state = State.Texture;
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void road_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/road.gif", true);
            Texture.Tag = "Road";
            state = State.Texture;
            Text = $"Editor RPG - [{Texture.Tag}]";
        }
        private void top_grass_btn_Click(object sender, System.EventArgs e)
        {
            Texture = new Bitmap("Data/Textures/top_grass.jpg");
            Texture.Tag = "Top grass";
            state = State.Texture;
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
