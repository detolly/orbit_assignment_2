using SpaceSim;
using Timer = System.Windows.Forms.Timer;

namespace Solsystemet
{
    public partial class Form1 : Form
    {
        Timer m_timer;

        public SpaceObjectControl FocusedControl { get; set; }

        public Font font;
        public SolidBrush text_brush;

        public event EventHandler<TickEventArgs> DoTick;

        double day_multiplier = 1;
        double day = 0;

        Point offset = new Point(0, 0);
        double magic = 1000000.0;

        const int FPS = 60;
        public bool ShowLabels { get; set; }

        public class TickEventArgs : EventArgs
        {
            public double Day { get; set; }
            public Point Offset { get; set; }
            public double Magic { get; set; } = 1000000.0;
            public Font Font { get; set; }
            public SolidBrush TextBrush { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;

            BackColor = Color.Black;
            label1.ForeColor = Color.White;

            KeyPreview = true;

            font = new Font("Arial", 12);
            text_brush = new SolidBrush(Color.Black);

            m_timer = new Timer();
            m_timer.Tick += (object? o, EventArgs args) => update();
            m_timer.Interval = 1000 / FPS;
            m_timer.Start();
        }

        public void update()
        {
            day += day_multiplier * 1/FPS;

            TickEventArgs args = new TickEventArgs();
            args.Day = day;
            args.Magic = magic;
            args.Offset = offset;
            args.Font = font;
            args.TextBrush = text_brush;

            DoTick?.Invoke(this, args);

            if (FocusedControl != null)
            {
                label1.Text = "Hovering: " + FocusedControl.m_space_object.get_name();
                foreach (SpaceObject obj in FocusedControl.m_space_object.get_orbiters())
                    label1.Text += "\n" + obj.get_name();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            FocusedControl = null;
            label1.Text = "";

            //offset.X -= (e.Location.X - (Width / 2)) / 10;
            //offset.Y -= (e.Location.Y - (Height / 2)) / 10;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.OemMinus)
                magic *= 2;
            else if (e.KeyCode == Keys.Oemplus)
                magic /= 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowLabels = !ShowLabels;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double d = Convert.ToDouble(textBox1.Text);
                day_multiplier = d;
            } catch (Exception ex) {}
            finally
            {
                textBox1.Text = "";
            }
        }
    }
}