namespace Contructors.Models;

public class BasePhone
{
    private string _brand;
    protected string _phoneType;
    protected string _connectionType;

    public BasePhone()
    {
        _phoneType = "Ahizeli Telefon";
    }

    public BasePhone(string brand, string connectionType)
    {
        _brand = brand;
        _connectionType = connectionType;
        _phoneType = "Ahizesiz Telefon";
    }

    // public string PhoneType => _phoneType;
    
    // public string PhoneType {get {return _phoneType;}}

    public string PhoneType { get; private set; /*class ichinde set edile biler cholden edile bilmez*/ } =
        "Ahizeli Telefon";

    public string Brand
    {
        get => _brand;
        set => _brand = value;
    }
    public string ConnectionType
    {
        get => _connectionType;
        set => _connectionType = value;
    }
    
    
    
    public virtual string Sound() => "Bip Bip Bip";
    
}




public class MobilePhone : BasePhone
{
    public bool HasCam { get; set; }
    
    public MobilePhone()
    {
        base._phoneType = "Mobil Telefon";
    }
    
    public MobilePhone(bool hasCam, string brand, string connectionType) : base(brand, connectionType)
    {
        HasCam = hasCam;
        // base.Brand = brand; base`in constructorunda hell olunur
        // base.ConnectionType = connectionType; base`in constructorunda hell olunur
    }
    
    public override string Sound() => "Bip Bip Bip Bip";
}

public class SmartPhone : MobilePhone
{
    public bool HasInternet { get; set; }
    
    public SmartPhone()
    {
        base._phoneType = "Smart Telefon";
    }
    
    public SmartPhone(bool hasInternet, bool hasCam, string brand, string connectionType) : base(hasCam, brand, connectionType)
    {
        HasInternet = hasInternet;
        // base.HasCam = hasCam; base`in constructorunda hell olunur
        // base.Brand = brand; base`in constructorunda hell olunur
        // base.ConnectionType = connectionType; base`in constructorunda hell olunur
    }
    
    public override string Sound() => "Bip Bip Bip Bip Bip";
}