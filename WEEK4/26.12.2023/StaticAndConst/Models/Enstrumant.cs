namespace StaticAndConst.Models;

// instance alinmadan ishledilecekse class abstract olmalidir. yalzin miras vermek olar
public abstract class Enstrumant
{
    public string Markasi { get; set; }
    public string Aciklamasi { get; set; }
    public string Modeli { get; set; }
    public string Rengi { get; set; }
    public decimal Fiyati { get; set; }

    // virtual yazanda istese override eder istemese etmez
    // abstract yazanda override etmek zorundadir mutleq implemet etmelidir metodu
    public abstract string Sound();
}

public class Gitar : Enstrumant
{
    public string Sap { get; set; }
    public string Teller { get; set; }
    public string Elektronik { get; set; }
    public override string Sound()
    {
        var gitarSesi = "Gitar sesi";
        return gitarSesi;
    }
}

public class Davul : Enstrumant
{
    public string Ziller { get; set; }
    public string Pedal { get; set; }
    public string KacPara { get; set; }
    public override string Sound()
    {
        var davulSesi = "Davul sesi";
        return davulSesi;
    }
}

public class Piyano : Enstrumant
{
    public string Tuslar { get; set; }
    public string Pedal { get; set; }
    public string Boyutu { get; set; }
    public override string Sound()
    {
        var piyanoSesi = "Piyano sesi";
        return piyanoSesi;
    }
}

public class Muzisyen
{
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}