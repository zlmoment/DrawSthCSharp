using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawSomething
{
    class MyMainPanel:System.Windows.Forms.Panel
    {

        public MyMainPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            return;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.DoubleBuffered = true;
            if (this.BackgroundImage != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.DrawImage(this.BackgroundImage, new System.Drawing.Rectangle(0, 0, this.Width, this.Height),
                0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height,
                System.Drawing.GraphicsUnit.Pixel);
            }
            base.OnPaint(e);
        }
    }
}
