using System;
using System.Drawing;
using System.Collections.Generic;

using System.Windows.Forms;

namespace SpaceSim
{
    public class Vector
    {
        public Vector(double x, double y) { this.x = x; this.y = y; }

        public double x;
        public double y;

        public override string ToString() { return String.Format("Vector: {{ {0}, {1} }}", x, y); }
    }

    public class SpaceObject
    {
        protected string name;

        public string get_name() { return name; }

        private static List<SpaceObject> objects = new List<SpaceObject>();

        public SpaceObject(string name)
        {
            this.name = name;
            objects.Add(this);

            set_color(Color.White);
        }
        ~SpaceObject()
        {
            objects.Remove(this);
        }
        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            Size s = sender.Size;

            graphics.Clear(Color.Transparent);

            graphics.FillEllipse(brush, new Rectangle(0, 0, s.Width, s.Height));
        }

        public static List<SpaceObject> all() => objects;

        public void set_rotational_period(double rotational_period) {
            this.rotational_period = rotational_period;
        }
        public void set_orbiting(SpaceObject orbiting, double orbital_radius, double orbital_period)
        {
            orbiting.orbiters.Add(this);

            this.orbiting = orbiting;
            this.orbital_radius = orbital_radius;
            this.orbital_period = orbital_period;
        }

        public void set_color(Color color) { this.color = color; }

        public List<SpaceObject> get_orbiters() => orbiters;

        public double get_orbital_radius() => orbital_radius;
        public double get_orbital_period() => orbital_period;
        public double get_rotational_period() => rotational_period;
        public Color get_color() => color;

        public Vector position_after_time(double t)
        {
            if (orbiting == null)
                return starting_position;

            double angle = (t / orbital_period) * 2 * Math.PI;

            Vector orbiting_position_after_time = orbiting.position_after_time(t);

            return new Vector(orbiting_position_after_time.x + orbital_radius * Math.Cos(angle), orbiting_position_after_time.y + orbital_radius * Math.Sin(angle));
        }

        public void set_position(Vector position) { starting_position = position; }

        private SpaceObject orbiting;
        private double orbital_radius;
        private double orbital_period;
        private double rotational_period;
        private Color color;

        List<SpaceObject> orbiters = new List<SpaceObject> ();

        Vector starting_position = zero_vector;

        private static readonly Vector zero_vector = new Vector(0.0, 0.0);

    }
    public class Star : SpaceObject
    {
        public Star(string name) : base(name)
        {
            set_color(Color.Yellow);
        }

        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }

    }
    public class Planet : SpaceObject
    {
        public Planet(string name) : base(name) {
            set_color(Color.Green);
        }

        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }


    }
    public class Moon : Planet
    {
        public Moon(string name) : base(name) {
            set_color(Color.White);
        }

        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }

    }

    public class Comet : SpaceObject
    {
        public Comet(string name) : base(name) {
            set_color(Color.LightBlue);
        }
        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }

    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(string name) : base(name) {
            set_color(Color.Gray);
        }

        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }

    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(string name, Asteroid[] asteroids) : base(name)
        { 
            this.asteroids = asteroids;
            set_color(Color.Gray);
        }
        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }


        private Asteroid[] asteroids;
    }

    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(string name) : base(name) { }

        public virtual void Draw(Control sender, Brush brush, Graphics graphics)
        {
            base.Draw(sender, brush, graphics);
        }

    }


}