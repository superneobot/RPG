using Engine.Map.GameObject;
using Engine.Map;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Game
{
    public partial class mainform : Form
    {
        Engine.Engine engine;
        Rectangle selected;
        Timer timer;
        Graphics graphics;
        Image drawTile;
        public mainform()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();
            //Application.Idle += delegate { Invalidate(); };
            engine = new Engine.Engine(this, Width, Height);
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Text = $"{engine.Direction} | {engine.Player.Bounds} | {selected}";
            //Text = $"{engine.Player.Bounds} | ";


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Update();
            graphics = e.Graphics;
            engine.World.Draw();
            
            engine.Player.Draw(e.Graphics);
            engine.Player.DrawStats(e.Graphics, engine.MiniMap.Width + 5, 1);
            engine.MiniMap.Draw(e.Graphics, engine.Player, engine.World);
            //engine.DrawBoxes(e.Graphics, new Engine.Map.GameObject.Crate());
            engine.World.Update(e.Graphics);
            //engine.DrawSelectedRect(e.Graphics, selected);

            //e.Graphics.DrawLine(new Pen(Color.Red, 4), new Point(Width / 2 - 8, 0), new Point(Width / 2 - 8, Height));

            base.OnPaint(e);
        }

        private void MoveTo(Rectangle rect)
        {
            engine.Player.Location = rect.Location;
        }

        private void mainform_MouseDown(object sender, MouseEventArgs e)
        {
            selected = engine.GetCurrentRect(e.X, e.Y);
            var tile = engine.GetCurrentTile(e.X, e.Y);
            //MoveTo(selected);
            drawTile = new Bitmap("Data/Textures/bottom_grass.jpg");
            //engine.World.AddTile(selected.Location.X / 32, selected.Location.Y / 32, drawTile);
            engine.World.AddBox(selected.Location.X / 32, selected.Location.Y / 32, 
                new Engine.Map.GameObject.Crate(this) 
                { 
                    Location = new Point(selected.Location.X, selected.Location.Y),
                    Bounds = new Rectangle(selected.Location.X, selected.Location.Y, 32,32)                    
                });

            Text = $"{engine.World.BoxesList.Count} {engine.World.BoxesList[0].Bounds}";
        }

        protected override void OnLoad(EventArgs e)
        {
            engine.Player.Name = "Aragorn";
            engine.Player.exp_max = 100; engine.Player.exp_evo = 10;
            LoadMap("Data/Maps/default.gamemap");
            engine.Updater.Start();

            base.OnLoad(e);
        }

        private void mainform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                engine.MoveLeft();
            }
            if (e.KeyCode == Keys.D)
            {
                engine.MoveRight();
            }
            if (e.KeyCode == Keys.W)
            {
                engine.MoveUp();
            }
            if (e.KeyCode == Keys.S)
            {
                engine.MoveDown();
            }
            if (e.KeyCode == Keys.Space)
            {
                engine.Cast();
            }
        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists("Data/Maps"))
            {
                SaveMap("Data/Maps/default.gamemap");
            }
            else
            {
                Directory.CreateDirectory("Data/Maps/");
            }
        }

        public void SaveMap(string path)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, engine.World.BoxesList);
            }
        }

        public void LoadMap(string path)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length > 0)
                    engine.World.BoxesList = (List<Crate>)formatter.Deserialize(fs);
            }
        }
    }
}
