namespace Activity.Application.Helper;

public static class Mapper
{
    public static TDestination Map<TSource, TDestination>(TSource source)
        where TSource : class
        where TDestination : class, new()
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var destination = new TDestination();
        var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.CanWrite);
            if (destinationProperty != null)
            {
                var value = sourceProperty.GetValue(source);

                // Handle DateOnly to DateTime conversion
                if (sourceProperty.PropertyType == typeof(DateOnly) && destinationProperty.PropertyType == typeof(DateTime))
                {
                    var dateOnlyValue = (DateOnly)value;
                    value = dateOnlyValue.ToDateTime(TimeOnly.MinValue); // Convert DateOnly to DateTime
                }
                // Handle other custom conversions if needed

                destinationProperty.SetValue(destination, value);
            }
        }

        return destination;
    }
}