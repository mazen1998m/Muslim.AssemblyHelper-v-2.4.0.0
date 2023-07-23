using Muslim.Assembly.Helper;
using System.Reflection;
using System.Security;

namespace Muslim.AssemblyHelper;

internal static class ThrowError
{

    public static void SecurityException(Exception e) => throw new SecurityException(ErrorMessage.SecurityException, e);

    public static void UnexpectedExceptions(Exception e) => throw new Exception(ErrorMessage.UnexpectedException, e);

    public static void InvalidCastException(Exception e) => throw new InvalidCastException(ErrorMessage.InvalidCastException, e);

    public static void TypeLoadException(Exception e) => throw new TypeLoadException(ErrorMessage.TypeLoadException, e);

    public static void FileNotFoundException(Exception e) => throw new FileNotFoundException(ErrorMessage.FileNotFoundException, e);

    public static void BadImageFormatException(Exception e) => throw new FileNotFoundException(ErrorMessage.BadImageFormatException, e);

    public static void FileLoadException(Exception e) => throw new FileLoadException(ErrorMessage.FileLoadException, e);

    public static void PathTooLongException(Exception e) => throw new PathTooLongException(ErrorMessage.PathTooLongException, e);

    public static void ArgumentException(Exception e) => throw new PathTooLongException(ErrorMessage.ArgumentException, e);

    public static void InvalidOperationException(Exception e) => throw new PathTooLongException(ErrorMessage.InvalidOperationException, e);
    public static void MethodAccessException(Exception e) => throw new MethodAccessException(ErrorMessage.MethodAccessException, e);

    public static void ReflectionTypeLoadException()
        => throw new ReflectionTypeLoadException
            (Type.EmptyTypes, Array.Empty<Exception>(), ErrorMessage.ReflectionTypeLoadException);

}