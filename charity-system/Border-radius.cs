using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace charity_system
{
    internal class Border


    {
        public  static void borderradius(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(control.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(control.Width - radius, control.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }


        // method for handle border color and thickness
        public static void ApplyBorder(Control control, Color color, int thickness)
        {
            control.Paint += (sender, e) =>
            {
                using (Pen pen = new Pen(color, thickness))
                {
                    Rectangle rect = new Rectangle(0, 0, control.Width - 1, control.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };
        }

    }
}
