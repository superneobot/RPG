﻿using System.Windows.Forms;

namespace EditorRPG
{
    public class ViewPortBox : Panel
    {
        public ViewPortBox()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
