using System.Reflection;

namespace Generic_object_mapper;

internal static class Mapper
{
    public static TResult Map<TSource, TResult>(TSource obj)
    {
        Type sourceType = typeof(TSource);
        Type resultType = typeof(TResult);

        PropertyInfo[] properties = sourceType.GetProperties();

        TResult result = Activator.CreateInstance<TResult>();

        foreach (PropertyInfo property in properties)
        {
            PropertyInfo? resultField = resultType.GetProperty(property.Name);
            if (resultField is not null && resultField.PropertyType == property.PropertyType)
            {
                resultField.SetValue(result, property.GetValue(obj));
            }
        }

        return result;
    }

    public static TResult Map<TSource, TResult>(TSource obj, Func<TSource, TResult> func)
    {
        Type sourceType = typeof(TSource);
        Type resultType = typeof(TResult);

        PropertyInfo[] properties = sourceType.GetProperties();

        TResult result = func.Invoke(obj);

        foreach (PropertyInfo property in properties)
        {
            PropertyInfo? resultField = resultType.GetProperty(property.Name);
            if (resultField is not null && resultField.PropertyType == property.PropertyType)
            {
                resultField.SetValue(result, property.GetValue(obj));
            }
        }

        return result;
    }
}
