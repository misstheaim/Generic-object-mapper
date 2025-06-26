using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Generic_object_mapper;

internal static class Mapper
{
    public static TResult Map<TSource, TResult>(TSource obj)
    {
        Type sourceType = typeof(TSource);
        Type resultType = typeof(TResult);

        if (obj == null)
        {
            throw new ArgumentNullException(sourceType.Name);
        }

        bool isConstrAvailable = false;
        var constructors = resultType.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
        foreach (ConstructorInfo constr in constructors)
        {
            if (constr.GetParameters().Length == 0) isConstrAvailable = true;
        }
        if (constructors.Length != 0 && !isConstrAvailable) throw new ArgumentException($"The type {resultType.FullName} doesn't have parameterless constructor.");

        PropertyInfo[] properties = sourceType.GetProperties();

        TResult result = Activator.CreateInstance<TResult>();

        foreach (PropertyInfo property in properties)
        {
            PropertyInfo? resultProperty = resultType.GetProperty(property.Name);
            if (resultProperty is null) continue;
            if (resultProperty.PropertyType == property.PropertyType)
            {
                resultProperty.SetValue(result, property.GetValue(obj));
            }
            else if (resultProperty.GetCustomAttribute<RequiredAttribute>() is not null)
            {
                throw new TargetException($"Trying to assign null value to required property {resultProperty.Name}");
            }
        }

        return result;
    }

    public static TResult Map<TSource, TResult>(TSource obj, Func<TSource, TResult> func)
    {
        Type sourceType = typeof(TSource);
        Type resultType = typeof(TResult);

        if (obj == null)
        {
            throw new ArgumentNullException(sourceType.Name);
        }

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
