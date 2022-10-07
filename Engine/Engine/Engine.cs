using Engine.Animation;
using Engine.Map;
using Engine.Player;
using System;
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
        /// Fireball
        /// </summary>
        public Fireball Fireball { get; set; }
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
        private int tile_x;
        private int tile_y;

        //public Crate Box;

        public Engine()
        {
            Animator = new Animator();
            Dir = new Direction();

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

        public string Info()
        {
            var a = tile_x;
            var b = tile_y;

            var x = Player.Bounds.Location.X / 32;
            var y = Player.Bounds.Location.Y / 32;

            string result = $"Box: {a} x {b} | Player: {x} x {y}";

            return result;
        }

        private DateTime lastUpdate = DateTime.MinValue;
        void Update()
        {
            var now = DateTime.Now;
            var dt = (float)(now - lastUpdate).TotalMilliseconds / 60f;
            //
            if (lastUpdate != DateTime.MinValue & Fireball != null)
            {
                Fireball.Update(dt);
            }
            //
            lastUpdate = now;
        }

        public void StartEngine()
        {
            World.Draw();
            LoadMap("Data/Maps/level_0.gamemap");
            World.Update();
            World.UpdateObjects();
            Player.Icon = new Bitmap("Data/Player/Down/frame_1.gif");
            Player.Draw();
            Player.DrawStats(MiniMap.Width, 0);
            Updater.Start();
            MiniMap.Draw(Player, World);

            Update();

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
            try
            {
                var tile = World.Boxes[Player.Bounds.X / 32 + 1, Player.Bounds.Y / 32];
                if (Player.Bounds.IntersectsWith(tile))
                {
                    Player.Location = new Point(Player.Location.X - Player.Speed, Player.Location.Y);
                }

                if (Player.Location.X + Player.Bounds.Width > World.Width)
                {
                    Player.Location = new Point(Player.Location.X - Player.Speed, Player.Location.Y);
                }
            }
            catch { }
        }
        public void MoveLeft()
        {
            Dir = Direction.Left;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X - Player.Speed, Player.Location.Y);
            try
            {
                var tile = World.Boxes[Player.Bounds.X / 32, Player.Bounds.Y / 32];
                if (Player.Bounds.IntersectsWith(tile))
                {
                    Player.Location = new Point(Player.Location.X + Player.Speed, Player.Location.Y);
                }
                if (Player.Location.X < 0)
                {
                    Player.Location = new Point(Player.Location.X + Player.Speed, Player.Location.Y);
                }
            }
            catch { }
        }
        public void MoveUp()
        {
            Dir = Direction.Up;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X, Player.Location.Y - Player.Speed);
            try
            {
                var tile = World.Boxes[Player.Bounds.X / 32, Player.Bounds.Y / 32];
                if (Player.Bounds.IntersectsWith(tile))
                {
                    Player.Location = new Point(Player.Location.X, Player.Location.Y + Player.Speed);
                }
                if (Player.Location.Y + Player.Height < World.TileSize.Y)
                {
                    Player.Location = new Point(Player.Location.X, Player.Location.Y + Player.Speed);
                }
            }
            catch { }
        }
        public void MoveDown()
        {
            Dir = Direction.Down;
            Player.Hero = Animator.Get(Dir);
            Animator.LoadStrip(Player.Type, Dir);
            Animator.RunAnimation();
            Player.Hero = Animator.OutImage;

            Player.Location = new Point(Player.Location.X, Player.Location.Y + Player.Speed);
            try
            {
                var tile = World.Boxes[Player.Bounds.X / 32, Player.Bounds.Y / 32 + 1];
                if (Player.Bounds.IntersectsWith(tile))
                {
                    Player.Location = new Point(Player.Location.X, Player.Location.Y - Player.Speed);
                }
                if (Player.Location.Y > World.Height - World.TileSize.Y)
                {
                    Player.Location = new Point(Player.Location.X, Player.Location.Y - Player.Speed);
                }
            }
            catch { }
        }
        public void Cast()
        {
            if (Dir == Direction.Right)
            {
                Fireball = new Fireball()
                {
                    Speed = 8.0F,
                    Position = new Point(Player.Location.X + 28, Player.Location.Y + 8)
                };
                Fireball.Velocity = new PointF(Fireball.Velocity.X + Fireball.Speed, Fireball.Velocity.Y);
            }
            if (Dir == Direction.Left)
            {
                Fireball = new Fireball()
                {
                    Speed = 8.0F,
                    Position = new Point(Player.Location.X - 14, Player.Location.Y + 8)
                };
                Fireball.Velocity = new PointF(Fireball.Velocity.X - Fireball.Speed, Fireball.Velocity.Y);
            }
            if (Dir == Direction.Up)
            {
                Fireball = new Fireball()
                {
                    Speed = 8.0F,
                    Position = new Point(Player.Location.X + 8, Player.Location.Y - 16)
                };
                Fireball.Velocity = new PointF(Fireball.Velocity.X, Fireball.Velocity.Y - Fireball.Speed);
            }
            if (Dir == Direction.Down)
            {
                Fireball = new Fireball()
                {
                    Speed = 8.0F,
                    Position = new Point(Player.Location.X + 8, Player.Location.Y + 28)
                };
                Fireball.Velocity = new PointF(Fireball.Velocity.X, Fireball.Velocity.Y + Fireball.Speed);
            }
        }

        public void LoadMap(string path)
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length > 0)
                {
                    World.Tiles = (Image[,])formatter.Deserialize(fs);
                    World.Boxes = (Rectangle[,])new BinaryFormatter().Deserialize(fs);
                    MiniMap.MiniMapBMP = (Image)new BinaryFormatter().Deserialize(fs);
                }
            }
        }

    }
}
