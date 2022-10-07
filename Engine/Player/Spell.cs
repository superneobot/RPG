using System.Drawing;

namespace Engine.Player
{
    public class Spell
    {
        //координаты
        public PointF Position { get; set; }
        //скорость
        public PointF Velocity { get; set; }
        //масса
        public float Mass { get; set; }
        //упругость
        public float Spring { get; set; }
        //гравитация
        public bool Gravity { get; set; }
        //приложенная сила
        public PointF Force { get; set; }
        public Spell()
        {
            Spring = 0.2f;
            Mass = 2;
            Gravity = false;
        }
        public virtual void Update(float dt)
        {
            //сила
            var force = Force;
            Force = Point.Empty;
            //гравитация
            if (Gravity)
                force = new PointF(force.X, force.Y + 9.8f * Mass);
            //ускорение
            var ax = force.X / Mass;
            var ay = force.Y / Mass;
            //скорость
            Velocity = new PointF(Velocity.X + ax * dt, Velocity.Y + ay * dt);
            //координаты
            Position = new PointF(Position.X + Velocity.X * dt, Position.Y + Velocity.Y * dt);
        }
    }
}
