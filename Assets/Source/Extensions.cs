using System.Reflection;
using System;

public static class Extensions
{
    public class EmptyArray<T>
    {
        static public readonly T[] Value = new T[0];
    }

    public static ConstructorInfo GetDefaultConstructor(this Type type)
    {
        var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        return type.GetTypeInfo().GetConstructor(flags, null, EmptyArray<Type>.Value, null);
    }

    public static object InvokeDefaultConstructor(this Type type)
    {
        return type.GetDefaultConstructor().Invoke(EmptyArray<object>.Value);
    }
}
