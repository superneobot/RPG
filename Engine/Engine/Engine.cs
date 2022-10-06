using Engine.Animation;
using Engine.Map;
using Engine.Map.GameObject;
using Engine.Player;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace EngineRPG
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public class Engine
    {
        public Direction Dir;
        /// <summary>
        /// World
        /// </summary>
        public World World { get; set; }
        /// <summary>
        /// Player
        /// </summary>
        public Player Player { get; set; }
        /// <summary>
        /// MiniMap
        /// </summary>
        public MiniMap MiniMap { get; set; }
        public Timer Updater;
        /// <summary>
        /// Gif Animator
        /// </summary>
        public Animator Animator;
        public Control Control;

        //public Crate Box;

        public Engine(Control control)
        {
            Animator = new Animator();
            Dir = new Direction();
            Control = control;

            Updater = new Timer()
            {
                Interval = 1000
            };
            Updater.Tick += Updater_Tick;
            //


        }

        private void Updater_Tick(object sender, System.EventArgs e)
        {
            if (Player.Health < Player.MaxHealth)
                Player.Health += 1;
        }

        public void StartEngine(Graphics graphics)
        {
            World.Draw(graphics);
            LoadMap("Data/Maps/map.gamemap");
            World.Update(graphics);
            Player.Icon = new Bitmap("Data/Player/Down/frame_1.gif");
            Player.Draw(graphics);
            Player.DrawStats(graphics, MiniMap.Width, 0);
            MiniMap.Draw(graphics, Player, World);
            
        }

        public void DrawSelectedRect(Graphics graph, Rectangle rect)
        {
            graph.FillRectangle(new SolidBrush(Color.White), rect);
        }
        public void Stop()
        {
            if (Dir == Direction.Left)
            {
                Player.Hero = Animator.Get(Dir);
            }
            if (Dir == Direction.Right)
            {
                Player.Hero = Animator.Get(Dir);
            }
            if (Dir == Direction.Up)
            {
                Player.Hero = Animator.Get(Dir);
            }
            if (Dir == Direction.Down)
            {
                Player.Hero = Animator.Get(Dir);
            }
        }
        public void MoveRight()
        {
            Dir = Direction.Right;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X + Player.Speed, Player.Location.Y);
            if (Player.Location.X + Player.Bounds.Width > World.Width)
            {
                Player.Location = new Point(Player.Location.X - Player.Speed, Player.Location.Y);
            }
            //if (Collision(crate_1.Bounds))
            //{
            //    Player.Speed = 0;
            //}
        }
        public void MoveLeft()
        {
            Dir = Direction.Left;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X - Player.Speed, Player.Location.Y);
            if (Player.Location.X < 0)
            {
                Player.Location = new Point(Player.Location.X + Player.Speed, Player.Location.Y);
            }
            //if (Collision(crate_1.Bounds))
            //{
            //    Player.Speed = 0;
            //}
        }
        public void MoveUp()
        {
            Dir = Direction.Up;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X, Player.Location.Y - Player.Speed);
            if (Player.Location.Y + Player.Height < World.TileSize.Y)
            {
                Player.Location = new Point(Player.Location.X, Player.Location.Y + Player.Speed);
            }
            //if (Collision(crate_1.Bounds))
            //{
            //    Player.Speed = 0;
            //}
        }
        public void MoveDown()
        {
            Dir = Direction.Down;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X, Player.Location.Y + Player.Speed);
            if (Player.Location.Y > World.Height - World.TileSize.Y)
            {
                Player.Location = new Point(Player.Location.X, Player.Location.Y - Player.Speed);
            }
            //if (Collision(crate_1.Bounds))
            //{
            //    Player.Speed = 0;
            //}
        }
        public void Cast()
        {
            if (Dir == Direction.Right)
            {
                //
            }
            if (Dir == Direction.Left)
            {
                //
            }
            if (Dir == Direction.Up)
            {
                //
            }
            if (Dir == Direction.Down)
            {
                //
            }
        }

        public void LoadMap(string path)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length > 0)
                    World.Tiles = (Image[,])formatter.Deserialize(fs);
            }
        }

    }
}
