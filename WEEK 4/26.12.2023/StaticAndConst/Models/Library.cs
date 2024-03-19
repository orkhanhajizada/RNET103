namespace StaticAndConst.Models;

public static class Library
{
    public static double Pi = 3.14;
    
    
    public const string ConnectionString = "Server=.;Database=Northwind;Trusted_Connection=True;";
    public static readonly string NewConnectionString = "Server=.;Database=Northwind;Trusted_Connection=True;";

}


