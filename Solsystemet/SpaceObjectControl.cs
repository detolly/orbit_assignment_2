using System;
using SpaceSim;

namespace Solsystemet
{
    public partial class SpaceObjectControl : UserControl
    {
        public SpaceObject m_space_object;
        Brush m_brush;

        public SpaceObjectControl(SpaceObject space_object)
        {
            m_space_object = space_object;
            m_brush = new SolidBrush(m_space_object.get_color());

            InitializeComponent();

            Size = new Size(32, 32);

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;

            DoubleBuffered = true;
            
            Program.form.DoTick += (object s, Form1.TickEventArgs args) =>
            {
                Form1 sender = (Form1)s;

                Vector pos = m_space_object.position_after_time(args.Day);
                Vector pos_on_screen = to_screen(pos, args.Magic);

                Point p;

                if (Program.form.FocusedControl != null)
                {
                    Vector pos_of_focused = to_screen(Program.form.FocusedControl.m_space_object.position_after_time(args.Day), args.Magic);
                    p = new Point((int)(pos_on_screen.x - pos_of_focused.x),(int)(pos_on_screen.y - pos_of_focused.y));
                } else
                {
                    p = new Point((int)pos_on_screen.x, (int)pos_on_screen.y);
                }

                p.X += sender.Width / 2;
                p.Y += sender.Height / 2;

                Location = p;
            };

            Paint += SpaceObjectControl_Paint;

        }

        private void SpaceObjectControl_Paint(object? sender, PaintEventArgs e)
        {
            m_space_object.Draw(this, m_brush, e.Graphics);
        }

        public Vector to_screen(Vector other, double magic)
        {
            return new Vector(((Width / 2) * other.x / magic), ((Height / 2) * other.y / (9 * magic / 16)));
        }

        private void SpaceObjectControl_MouseClick(object sender, MouseEventArgs e)
        {
            Program.form.FocusedControl = this;
        }
    }
}
