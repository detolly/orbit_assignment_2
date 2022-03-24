
namespace SpaceSim
{
    public static class Sun
    {
        public static Star Instance
        {
            get; private set;
        }

        static Sun()
        {
            fill_solar_system();
        }

        private static void fill_solar_system()
        {
            Star sun = new Star("Sun");

            Planet mercury = new Planet("Mercury");
            Planet venus = new Planet("Venus");
            Planet earth = new Planet("Earth");
            Planet mars = new Planet("Mars");
            Planet jupiter = new Planet("Jupiter");
            Planet saturn = new Planet("Saturn");
            Planet uranus = new Planet("Uranus");
            Planet neptune = new Planet("Neptune");
            Planet pluto = new DwarfPlanet("Pluto");

            mercury.set_orbiting(sun, 57910, 87.97);
            venus.set_orbiting(sun, 108200, 224.7);
            earth.set_orbiting(sun, 149600, 365.26);
            mars.set_orbiting(sun, 227940, 686.98);
            jupiter.set_orbiting(sun, 778330, 4332.71);
            saturn.set_orbiting(sun, 1429400, 10759.5);
            uranus.set_orbiting(sun, 2870990, 30685.00);
            neptune.set_orbiting(sun, 4504300, 60190.00);
            pluto.set_orbiting(sun, 5913520, 90550.00);

            Moon moon = new Moon("Moon");

            moon.set_orbiting(earth, 384.00, 27.32);

            Moon Phobos = new Moon("Phobos");
            Moon Deimos = new Moon("Deimos");

            Phobos.set_orbiting(mars, 9, 0.32);
            Deimos.set_orbiting(mars, 23, 46023.00);

            Moon Metis = new Moon("Metis");
            Moon Adrastea = new Moon("Adrastea");
            Moon Amalthea = new Moon("Amalthea");
            Moon Thebe = new Moon("Thebe");
            Moon Io = new Moon("Io");
            Moon Europa = new Moon("Europa");
            Moon Ganymede = new Moon("Ganymede");
            Moon Callisto = new Moon("Callisto");
            Moon Leda = new Moon("Leda");
            Moon Himalia = new Moon("Himalia");
            Moon Lysithea = new Moon("Lysithea");
            Moon Elara = new Moon("Elara");
            Moon Ananke = new Moon("Ananke");
            Moon Carme = new Moon("Carme");
            Moon Pasiphae = new Moon("Pasiphae");
            Moon Sinope = new Moon("Sinope");

            Metis.set_orbiting(jupiter, 128, 0.29);
            Adrastea.set_orbiting(jupiter, 129, 0.3);
            Amalthea.set_orbiting(jupiter, 181, 0.5);
            Thebe.set_orbiting(jupiter, 222, 0.67);
            Io.set_orbiting(jupiter, 422, 28126.00);
            Europa.set_orbiting(jupiter, 671, 20149.00);
            Ganymede.set_orbiting(jupiter, 1070, 42186.00);
            Callisto.set_orbiting(jupiter, 1883, 16.69);
            Leda.set_orbiting(jupiter, 11094, 238.72);
            Himalia.set_orbiting(jupiter, 11480, 250.57);
            Lysithea.set_orbiting(jupiter, 11720, 259.22);
            Elara.set_orbiting(jupiter, 11737, 259.65);
            Ananke.set_orbiting(jupiter, 21200, -631.00);
            Carme.set_orbiting(jupiter, 22600, -692.00);
            Pasiphae.set_orbiting(jupiter, 23500, -735.00);
            Sinope.set_orbiting(jupiter, 23700, -758.00);

            mercury.set_orbiting(sun, 57010.0, 87.97);

            Instance = sun;
        }
    }
}
