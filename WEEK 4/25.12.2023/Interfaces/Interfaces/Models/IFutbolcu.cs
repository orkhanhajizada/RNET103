namespace Interfaces.Models;

public interface IFutbolcu
{
     public string? Firstname { get; set; }
     public string? LastName { get; set; }
     public string? UniformNumber { get; set; }
     public string? Position { get; set; }
     public string? Takvim { get; set; }
     public byte SutGucu { get; set; }
     public byte Agresiflik { get; set; }
     public bool MilliFutbolcu { get; set; }

     public void SutCek();
}


public class Kaleci : IFutbolcu
{
     public string? Firstname { get; set; }
     public string? LastName { get; set; }
     public string? UniformNumber { get; set; }
     public string? Position { get; set; }
     public string? Takvim { get; set; }
     public byte SutGucu { get; set; }
     public byte Agresiflik { get; set; }
     public byte ElleTopKontrolu { get; set; }
     public bool MilliFutbolcu { get; set; }

     public void SutCek()
     {
          Console.WriteLine("Ortalama Sut hizi " + SutGucu);
     }
}

public class Forvet : IFutbolcu
{
     public string? Firstname { get; set; }
     public string? LastName { get; set; }
     public string? UniformNumber { get; set; }
     public string? Position { get; set; }
     public string? Takvim { get; set; }
     public byte SutGucu { get; set; }
     public byte Agresiflik { get; set; }
     public bool MilliFutbolcu { get; set; }


     public void SutCek()
     {
          Console.WriteLine("Ortalama Sut hizi " + SutGucu);
     }
}

public class Defans
{
     public string? Firstname { get; set; }
     public string? LastName { get; set; }
     public string? UniformNumber { get; set; }
     public string? Position { get; set; }
     public string? Takvim { get; set; }
     public byte SutGucu { get; set; }
     public byte Agresiflik { get; set; }
     public bool MilliFutbolcu { get; set; }


     public void SutCek()
     {
          Console.WriteLine("Ortalama Sut hizi " + SutGucu);
     }
}