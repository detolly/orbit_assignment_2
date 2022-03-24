using SpaceSim;

namespace Solsystemet
{
    internal static class Program
    {

        public static Form1 form;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new Form1();

            Sun.Instance.set_color(Color.Yellow);

            foreach (SpaceObject obj in SpaceObject.all())
                form.Controls.Add(new SpaceObjectControl(obj));

            Application.Run(form);
        }
    }
}