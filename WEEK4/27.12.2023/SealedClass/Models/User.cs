namespace SealedClass.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class UserDto
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public interface IMapper<TSource, TDestination>
{
    TDestination Map(TSource source);
}

public class Mapper<TSource, TDestination> : IMapper<TSource, TDestination>
{
    public TDestination Map(TSource source)
    {
        var destination = Activator.CreateInstance<TDestination>();

        var sourceProperties = source.GetType().GetProperties();
        var destinationProperties = destination.GetType().GetProperties();

        
        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destinationProperty in destinationProperties)
            {
                if (sourceProperty.Name == destinationProperty.Name)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }

        return destination;
    }
}