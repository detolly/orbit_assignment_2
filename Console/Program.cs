using SpaceSim;

class Program
{

    static void Main(string[] args)
    {

        Console.Write("Number of days since time 0: ");
        string received = Console.ReadLine();
        long time = Convert.ToInt64(received);
        Console.Write("Planet name: ");
        received = Console.ReadLine();
        SpaceObject found = null;
        foreach(SpaceObject so in SpaceObject.all())
        {
            if (so.get_name() == received)
            {
                found = so;
                break;           
            }
        }

        if (found == null)
            found = Sun.Instance;

        Console.WriteLine(string.Format("{0}: {1}", found.get_name(), found.position_after_time(time)));
        foreach (SpaceObject o in found.get_orbiters())
            Console.WriteLine(string.Format("{0}: {1}", o.get_name(), o.position_after_time(time)));

    }
}
