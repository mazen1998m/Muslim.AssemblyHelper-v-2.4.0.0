using Microsoft.Build.Construction;
using System.Security;
// ReSharper disable once CheckNamespace
namespace Muslim.Assembly.Helper;

using System;
using System.Reflection;
public static class AssemblyHelper
{
    #region Cache

    private static readonly Dictionary<Type, string> AssemblyNameByTypeCache = new();

    private static readonly Dictionary<string, Assembly> AssemblyByNameCache = new();
    private static readonly Dictionary<Type, Assembly> AssemblyByTypeCache = new();


    #endregion

    #region Get Assembly

    /// <summary>
    /// Gets the Assembly of the currently executing code.
    /// </summary>
    /// <remarks>
    /// This method retrieves the Assembly instance of the code that calls it.
    /// If the Assembly is successfully retrieved, it will be returned.
    /// In case of any exceptions during the process, corresponding custom error methods will be called,
    /// and a null reference will be returned.
    /// </remarks>
    /// <returns>
    /// The Assembly of the currently executing code if successful; otherwise, null.
    /// </returns>
    /// <exception cref="FileNotFoundException">Thrown when the executing assembly file is not found.</exception>
    /// <exception cref="BadImageFormatException">Thrown when the executing assembly is not a valid image format.</exception>
    /// <exception cref="SecurityException">Thrown when there is a security violation.</exception>
    /// <exception cref="FileLoadException">Thrown when the executing assembly cannot be loaded.</exception>
    /// <exception cref="Exception">Thrown for any other unexpected exceptions.</exception>
    public static Assembly GetAssembly()
    {
        try
        {
            return Assembly.GetExecutingAssembly();
        }
        catch (FileNotFoundException exception)
        {
            ThrowError.FileNotFoundException(exception);
        }
        catch (BadImageFormatException exception)
        {
            ThrowError.BadImageFormatException(exception);
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
        }
        catch (FileLoadException exception)
        {
            ThrowError.FileLoadException(exception);
        }
        catch (Exception exception)
        {
            ThrowError.UnexpectedExceptions(exception);
        }

        return default!;
    }

    /// <summary>
    /// Gets the assembly that contains the specified type or return the current assembly if
    /// type is null
    /// </summary>
    /// <param name="type">The type whose assembly to retrieve.</param>
    /// <returns>The assembly that contains the specified type or return the current assembly if type is null.</returns>
    /// <exception cref="SecurityException">Thrown when there is a security error.</exception>
    /// <exception cref="TypeLoadException">Thrown when a type cannot be loaded.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when there is an error loading types.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when the assembly is found but cannot be loaded due to an error in the file format or a mismatch in the processor architecture.</exception>
    /// <exception cref="BadImageFormatException">Thrown when assembly is not a valid assembly or assembly is targeted for a different version of the runtime.</exception>
    /// <exception cref="InvalidOperationException">Thrown when assembly is not a valid assembly or assembly is targeted for a different version of the runtime.</exception>
    public static Assembly GetAssembly(Type? type)
    {
        if (type == null) return GetAssembly();
        try
        {
            return (AssemblyByTypeCache.ContainsKey(type)) ? AssemblyByTypeCache[type] : RegisterAssemblyInCache(type);
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
        }
        catch (TypeLoadException exception)
        {
            ThrowError.TypeLoadException(exception);
        }
        catch (ReflectionTypeLoadException)
        {
            ThrowError.ReflectionTypeLoadException();
        }
        catch (FileNotFoundException exception)
        {
            ThrowError.FileNotFoundException(exception);
        }
        catch (FileLoadException exception)
        {
            ThrowError.FileLoadException(exception);
        }
        catch (BadImageFormatException exception)
        {
            ThrowError.BadImageFormatException(exception);
        }
        catch (InvalidOperationException exception)
        {
            ThrowError.InvalidOperationException(exception);
        }

        return default!;

    }

    /// <summary>
    /// Gets the assembly based on the provided assembly name or return the current assembly if
    /// assemblyName is null
    /// </summary>
    /// <param assemblyName="type">The assembly name whose assembly to retrieve.</param>
    /// <returns>assembly based on the provided assembly name or return the current assembly if assemblyName is null</returns>
    /// <exception cref="SecurityException">Thrown when there is a security error.</exception>
    /// <exception cref="PathTooLongException">Thrown when assembly name exceeds the maximum allowed path length</exception>
    /// <exception cref="ArgumentException">Thrown when assembly name contains invalid characters or is an invalid format.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when the assembly is found but cannot be loaded due to an error in the file format or a mismatch in the processor architecture.</exception>
    /// <exception cref="BadImageFormatException">Thrown when assembly is not a valid assembly or assembly is targeted for a different version of the runtime.</exception>
    /// <exception cref="InvalidOperationException">Thrown when assembly is not a valid assembly or assembly is targeted for a different version of the runtime.</exception>
    public static Assembly GetAssembly(string? assemblyName)
    {
        if (string.IsNullOrEmpty(assemblyName)) return GetAssembly();

        try
        {
            var assembly = AssemblyByTypeCache.FirstOrDefault(x => x.Value.GetName().Name == assemblyName).Value;
            if (assembly != null) return assembly;
            return AssemblyByNameCache.ContainsKey(assemblyName)
                ? AssemblyByNameCache[assemblyName]
                : RegisterAssemblyNameInCache(assemblyName);
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
        }
        catch (PathTooLongException exception)
        {
            ThrowError.PathTooLongException(exception);
        }

        catch (FileNotFoundException exception)
        {
            ThrowError.FileNotFoundException(exception);
        }
        catch (FileLoadException exception)
        {
            ThrowError.FileLoadException(exception);
        }
        catch (BadImageFormatException exception)
        {
            ThrowError.BadImageFormatException(exception);
        }
        catch (ArgumentException exception)
        {
            ThrowError.ArgumentException(exception);
        }
        catch (InvalidOperationException exception)
        {
            ThrowError.InvalidOperationException(exception);
        }

        return default!;

    }

    /// <summary>
    /// Gets the Assembly of the currently executing code or the Assembly associated with the specified object's type.
    /// </summary>
    /// <param name="object">The object whose type's Assembly needs to be retrieved.</param>
    /// <returns>
    /// The Assembly of the currently executing code if the object is null or the Assembly associated with the specified object's type.
    /// If successful, the corresponding Assembly will be returned; otherwise, null.
    /// </returns>
    /// <exception cref="SecurityException">Thrown when there is a security violation.</exception>
    /// <exception cref="TypeLoadException">Thrown when the specified type cannot be loaded.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when there is an error loading types from an assembly.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when the assembly cannot be loaded.</exception>
    /// <exception cref="BadImageFormatException">Thrown when the assembly is not a valid image format.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
    public static Assembly GetAssembly(object? @object) => @object is not null ? GetAssembly(@object.GetType()) : GetAssembly();


    #endregion

    #region Get Assembly Name


    public static string GetAssemblyName() => GetAssembly().GetName().Name!;
    public static string GetAssemblyName(Assembly? assembly) => assembly is not null ? assembly.GetName().Name! : GetAssemblyName();
    public static string GetAssemblyName(Type? type)
    {
        if (type is null) return GetAssemblyName();
        try
        {
            return AssemblyNameByTypeCache.ContainsKey(type)
                ? AssemblyNameByTypeCache[type]
                : RegisterAssemblyNameInCache(type, GetAssembly(type));
        }
        catch (Exception)
        {
            throw;
        }

        return GetAssemblyName();
    }
    public static List<string> GetAssemblysName()
        => GetAllAssembly().Select(assembly => assembly.GetName().Name!).ToList();
    public static string GetAssemblyName(object? @object) => @object is not null ? GetAssemblyName(@object.GetType()) : GetAssemblyName();

    #endregion

    #region Get Assembly Name Length

    public static int GetAssemblyNameLength(string assemblyName) => assemblyName.Split(".").Length;

    public static int GetAssemblyNameLength(Type assemblyType) => GetAssemblyName(assemblyType).Split(".").Length;

    #endregion

    #region GetAllAssembly
    public static List<Assembly> GetAllAssembly()
    {

        var projectName = System.Reflection.Assembly.GetExecutingAssembly().FullName!.Split(".").First();

        var solutionFiles = SolutionFile
            .Parse(FindSolutionFile()).ProjectsInOrder
            .Select(x => x.ProjectName)
            .Where(project => project.StartsWith(projectName))
            .ToList();

        var solutionAssemblys = solutionFiles.Select(GetAssembly).ToList();
        return solutionAssemblys;

    }

    #endregion


    #region GetType

    public static IEnumerable<Type> GeTypeByName(Assembly assembly, string typeName) => assembly.GetTypes().Where(v => v.FullName!.Contains(typeName));

    public static IEnumerable<Type> GeTypeByName(string typeName)
    {
        List<Type> allTypes = new();
        var allAssembly = GetAllAssembly();
        foreach (
            IEnumerable<Type>? types in allAssembly
                .Select(assembly => assembly
                    .GetTypes()
                    .Where(v => v.FullName!.Contains(typeName))))
        {
            allTypes.AddRange(types);
        }

        return allTypes;
    }

    public static IEnumerable<Type> GetTypes()
    {
        List<Type> allTypes = new();
        var allAssembly = GetAllAssembly();
        foreach (Type[]? types in allAssembly.Select(assembly => assembly.GetTypes()))
        {
            allTypes.AddRange(types);
        }

        return allTypes;
    }

    public static Type GetType(string typeName)
    {
        Type? type = null;
        foreach (Type? assemblyType
                 in GetAllAssembly().Select(assembly => assembly.GetType(typeName))
                     .Where(assemblyType => assemblyType != null))
        {
            type = assemblyType;
        }

        return type!;
    }


    #endregion

    #region Help
    private static string FindSolutionFile()
    {
        var currentDirectory = Directory.GetCurrentDirectory();

        // Search for the solution file in the current directory and its parent directories
        string? solutionFilePath = null;
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        while (currentDirectory != null)
        {
            solutionFilePath = Directory.EnumerateFiles(currentDirectory, "*.sln").FirstOrDefault()!;

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (solutionFilePath != null)
                break;

            currentDirectory = Directory.GetParent(currentDirectory)!.FullName;
        }

#pragma warning disable CS8603
        return solutionFilePath;
#pragma warning restore CS8603
    }
    #endregion


    #region Register In Cache method

    private static string RegisterAssemblyNameInCache(Type type, Assembly assembly)
    {
        var assemblyName = assembly.GetName().Name;
        AssemblyNameByTypeCache[type] = assemblyName!;
        return assemblyName!;
    }

    private static Assembly RegisterAssemblyNameInCache(string assemblyName)
    {
        var assembly = Assembly.Load(assemblyName);
        AssemblyByNameCache[assemblyName] = assembly;
        return assembly;
    }

    private static Assembly RegisterAssemblyInCache(Type type)
    {
        var assembly = Assembly.GetAssembly(type);
        AssemblyByTypeCache[type] = assembly!;
        return assembly!;
    }

    #endregion

    #region other
    //this must move to other library
    //public static List<Type> GetConstructors() => (from type in GetTypes().Where(t => t.FullName!.StartsWith(GetAssemblyName(t)))
    //                                               from constructor in type.GetConstructors()
    //                                               from parameter in constructor.GetParameters()
    //                                               select parameter.ParameterType).ToList();

    #endregion

}

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

    public static void ReflectionTypeLoadException()
        => throw new ReflectionTypeLoadException
            (Type.EmptyTypes, Array.Empty<Exception>(), ErrorMessage.ReflectionTypeLoadException);

}

internal static class ErrorMessage
{
    public const string NullReferenceException = "The type '{0}' is null.";
    public const string SecurityException = "Insufficient permissions to access the assembly.";
    public const string InvalidCastException = "Invalid type cast.";
    public const string TypeLoadException = "Unable to load the specified type.";
    public const string FileNotFoundException = "The file was not found.";
    public const string ReflectionTypeLoadException = "Unable to load one or more types.";
    public const string BadImageFormatException = "assembly is not a valid assembly or assembly is targeted for a different version of the runtime.";
    public const string PathTooLongException = "the specified assembly name exceeds the maximum allowed path length.";
    public const string FileLoadException = "assembly is found but cannot be loaded due to an error in the file format or a mismatch in the processor architecture.";
    public const string ArgumentException = "This exception can be thrown if assembly name contains invalid characters or is an invalid format.";
    public const string InvalidOperationException = "This exception can be thrown if the assembly has already been loaded into the current application and cannot be loaded again.";
    public const string UnexpectedException = "An unexpected error occurred.";
}



