using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;
using System.Threading.Channels;

Kettle kettle = new Kettle("Ketti", "Ketti's charactericts");

kettle.Sound();

microwave microwave = new("Micric","Micric's characteristics");

Cello cello = new ("Cellok", "Cellok's charactericts");

cello.Sound();

public class Device
{
    public string name;
    public string characteristic;
    public Device() 
    {
        Console.WriteLine("Device constructor");
    }

    public Device(string name,string characteristic)
    {
       this.name = name;
       this.characteristic = characteristic;
        Console.WriteLine("Device constructor");
    }

    public virtual void Sound()
    {
        Console.WriteLine("Device sound");
    }
    public virtual void Show()
    {
        Console.WriteLine("Show device");
    }
    public virtual void Desc()
    {
        Console.WriteLine("Device description");
    }
}

public class Kettle : Device
{
    public Kettle()
    {
        Console.WriteLine("Kettle constructor");
    }

    public Kettle(string name, string characteristic)
    {
        this.name = name;
        this.characteristic = characteristic;
        Console.WriteLine("Kettle constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Viiiiiiii");
    }
    public override void Show()
    {
        Console.WriteLine(base.name);
    }
    public override void Desc()
    {
        Console.WriteLine(base.characteristic);
    }
}

public class microwave : Device
{
    public microwave()
    {
        Console.WriteLine("Microwave constructor");
    }

    public microwave(string name, string characteristic)
    {
        base.name = name;
        base.characteristic = characteristic;
        Console.WriteLine("Microwave constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("MMMMMMMMM");
    }
    public override void Show()
    {
        Console.WriteLine(base.name);
    }
    public override void Desc()
    {
        Console.WriteLine(base.characteristic);
    }
}

public class car : Device
{ public car()
    {
        Console.WriteLine("Car constructor");
    }

    public car(string name, string characteristic)
    {
        this.name = name;
        this.characteristic = characteristic;
        Console.WriteLine("Car constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Hmmmm");
    }
    public override void Show()
    {
        Console.WriteLine(this.name);
    }
    public override void Desc()
    {
        Console.WriteLine(this.characteristic);
    }
}

public class ferry : Device
{
    public ferry()
    {
        Console.WriteLine("Ferry constructor");
    }

    public ferry(string name, string characteristic)
    {
        base.name = name;
        base.characteristic = characteristic;
        Console.WriteLine("Ferry constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Gummmmmm");
    }
    public override void Show()
    {
        Console.WriteLine(this.name);
    }
    public override void Desc()
    {
        Console.WriteLine(this.characteristic);
    }
}

public class Musical_instrument 
{
    public string name;
    public string characteristic;
    public Musical_instrument()
    {
        Console.WriteLine("Musical instrument constructor");
    }
    public Musical_instrument(string name, string characteristic)
    {
        this.name = name;
        this.characteristic = characteristic;
        Console.WriteLine("Musical instrument constructor");
    }
    public virtual void Sound()
    {
        Console.WriteLine("Musical instrument sound");
    }
    public virtual void Show()
    {
        Console.WriteLine("Show musical instrument");
    }
    public virtual void Desc()
    {
        Console.WriteLine("Musical instrument description");
    }

    public virtual void History()
    {
        Console.WriteLine("Musical instrument history");
    }
}

public class Violin : Musical_instrument
{
    public Violin()
    {
        Console.WriteLine("Violin constructor");
    }
    public Violin(string name, string characteristic)
    {
        base.name = name;
        base.characteristic = characteristic;
        Console.WriteLine("Violin constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Pinnnnn");
    }
    public override void Show()
    {
        Console.WriteLine(base.name);
    }
    public override void Desc()
    {
        Console.WriteLine(base.characteristic);
    }

    public override void History()
    {
        Console.WriteLine("Violin history");
    }

}

public class Trombone : Musical_instrument
{
    public Trombone()
    {
        Console.WriteLine("Trombone constructor");
    }
    public Trombone(string name, string characteristic)
    {
        base.name = name;
        base.characteristic = characteristic;
        Console.WriteLine("Trombone constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Vuvuvu");
    }
    public override void Show()
    {
        Console.WriteLine(base.name);
    }
    public override void Desc()
    {
        Console.WriteLine(base.characteristic);
    }

    public override void History()
    {
        Console.WriteLine("Trombone history");
    }

}

public class Ukulele : Musical_instrument
{
    public Ukulele()
    {
        Console.WriteLine("Ukulele constructor");
    }
    public Ukulele(string name, string characteristic)
    {
        base.name = name;
        base.characteristic = characteristic;
        Console.WriteLine("Ukulele constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Pinnnmm");
    }
    public override void Show()
    {
        Console.WriteLine(base.name);
    }
    public override void Desc()
    {
        Console.WriteLine(base.characteristic);
    }

    public override void History()
    {
        Console.WriteLine("Ukulele history");
    }

}

public class Cello : Musical_instrument
{
    public Cello()
    {
        Console.WriteLine("Cello constructor");
    }
    public Cello(string name, string characteristic)
    {
        base.name = name;
        base.characteristic = characteristic;
        Console.WriteLine("Cello constructor");
    }
    public override void Sound()
    {
        Console.WriteLine("Pummmm");
    }
    public override void Show()
    {
        Console.WriteLine(base.name);
    }
    public override void Desc()
    {
        Console.WriteLine(base.characteristic);
    }

    public override void History()
    {
        Console.WriteLine("Cello history");
    }
}