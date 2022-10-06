using EngineRPG;
using System;
using System.Drawing;
using Timer = System.Windows.Forms.Timer;

namespace Engine.Animation
{
    public class Animator
    {
        public Image[] Strip { get; set; }
        public Image OutImage;
        public string filename;
        int cadr = 0;
        Timer timer;
        public Animator()
        {
            Strip = new Image[5];
            //OutImage = Get();
            timer = new Timer();
            timer.Interval = 200;
            timer.Tick += Timer_Tick;
            OutImage = new Bitmap($"Data/Player/Down/frame_1.gif");
        }

        public Image Get(Direction dir)
        {
            var Image = new Bitmap($"Data/Player/{dir}/frame_1.gif");
            return Image;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            OutImage = Strip[cadr];
            cadr++;
            if (cadr == Strip.Length) cadr = 0;
        }

        public void LoadStrip(string type, Direction dir)
        {
            //Strip[0] = new Bitmap($"Data/{e}/{dir}/frame_" + 0 + ".gif", true);
            for (int i = 0; i < 5; i++)
            {
                Strip[i] = new Bitmap($"Data/{type}/{dir}/frame_" + i + ".gif", true);
            }
        }

        public Image NPC(string type)
        {
            return Strip[1] = new Bitmap($"Data/{type}/Down/frame_" + 1 + ".gif", true);
        }

        public void RunAnimation()
        {
            timer.Start();
        }
    }
}
