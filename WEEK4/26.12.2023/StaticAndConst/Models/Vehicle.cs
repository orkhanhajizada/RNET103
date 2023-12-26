namespace StaticAndConst.Models;

public abstract class Vehicle
{
    public decimal DriveTime { get; set; }
    public string DrivePath { get; set; }

    void AvareageSpeed()
    {
        Console.WriteLine("Average Speed");
    }
}

public interface IEngine
{
    string HorsePower();
    string TankSize();
    string CurrentOil();
    string FuelType();
    string RemaingOilAmount();
}

public interface IWheel
{
    string WheelTickness();
}

public interface ITransmission
{
    string TransmissionKind();
}

public class Car : Vehicle, IEngine, IWheel, ITransmission
{
    public byte DoorCount { get; set; }
    public string Wincode { get; set; }

    public string HorsePower()
    {
        return "Car Horse Power";
    }

    public string TankSize()
    {
        return "Car Tank Size";
    }

    public string CurrentOil()
    {
        return "Car Current Oil";
    }

    public string FuelType()
    {
        return "Car Fuel Type";
    }

    public string RemaingOilAmount()
    {
        return "Car Remaing Oil Amount";
    }

    public string WheelTickness()
    {
        return "Car Wheel Tickness";
    }

    public string TransmissionKind()
    {
        return "Car Transmission Kind";
    }
}

public class Bicycle : Vehicle, IWheel
{
    public string PedalKind { get; set; }

    public string WheelTickness()
    {
        return "Bicycle Wheel Tickness";
    }
}

public class Plane : Vehicle, IEngine, IWheel
{
    public string HorsePower()
    {
        return "Plane Horse Power";
    }

    public string TankSize()
    {
        return "Plane Tank Size";
    }

    public string CurrentOil()
    {
        return "Plane Current Oil";
    }

    public string FuelType()
    {
        return "Plane Fuel Type";
    }

    public string RemaingOilAmount()
    {
        return "Plane Remaing Oil Amount";
    }

    public string WheelTickness()
    {
        return "Plane Wheel Tickness";
    }
}