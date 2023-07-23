using Microsoft.Build.Construction;
using Muslim.AssemblyHelper;
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
    private static IEnumerable<Assembly>? _allAssemblies;

    #endregion

    //done readme
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
    /// <returns>
    /// The Assembly that contains the specified type or the Assembly of the currently executing code if the type is null.
    /// If successful, the corresponding Assembly will be returned; otherwise, Assembly of the currently executing code.
    /// </returns>
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

        return GetAssembly();

    }

    /// <summary>
    /// Gets the assembly based on the provided assembly name or return the current assembly if
    /// assemblyName is null or empty
    /// </summary>
    /// <param assemblyName="type">The assembly name whose assembly to retrieve.</param>
    /// <returns>
    /// The Assembly based on the provided assembly name or the Assembly of the currently executing code if the assembly name is null or empty.
    /// If successful, the corresponding Assembly will be returned; otherwise, Assembly of the currently executing code.</returns>
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
            if (assembly! != default) return assembly;
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

        return GetAssembly();

    }

    /// <summary>
    /// Gets the Assembly of the currently executing code or the Assembly associated with the specified object's type.
    /// </summary>
    /// <param name="object">The object whose type's Assembly needs to be retrieved.</param>
    /// <returns>
    /// The Assembly associated with the specified object's type or the Assembly of the currently executing code if the object is null.
    /// If successful, the corresponding Assembly will be returned; otherwise, Assembly of the currently executing code.
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


    /// <summary>
    /// Gets the name of the assembly from the loaded assembly.
    /// </summary>
    /// <returns>The name of the loaded assembly.</returns>
    /// <exception cref="SecurityException">Thrown when a security error occurs while accessing the assembly.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when an error occurs while loading the assembly file.</exception>
    /// <exception cref="BadImageFormatException">Thrown when the assembly file has an invalid format.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when an error occurs while loading types in the assembly.</exception>
    public static string GetAssemblyName()
    {

        try
        {
            return GetAssembly().GetName().Name!;
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
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
        catch (ReflectionTypeLoadException)
        {
            ThrowError.ReflectionTypeLoadException();
        }


        return default!;
    }

    /// <summary>
    /// Gets the name of the assembly from the provided loaded assembly. If no assembly is provided, it will retrieve the name of the currently executing assembly.
    /// </summary>
    /// <param name="assembly">The loaded assembly from which to retrieve the name.</param>
    /// <returns>The name of the provided assembly or the currently executing assembly.</returns>
    /// <exception cref="SecurityException">Thrown when a security error occurs while accessing the assembly.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when an error occurs while loading the assembly file.</exception>
    /// <exception cref="BadImageFormatException">Thrown when the assembly file has an invalid format.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when an error occurs while loading types in the assembly.</exception>
    public static string GetAssemblyName(Assembly? assembly)
    {
        try
        {
            return assembly is not null ? assembly.GetName().Name! : GetAssemblyName();
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
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
        catch (ReflectionTypeLoadException)
        {
            ThrowError.ReflectionTypeLoadException();
        }


        return default!;
    }

    /// <summary>
    /// Gets the name of the assembly from the provided type's assembly. If no type is provided, it will retrieve the name of the currently executing assembly.
    /// </summary>
    /// <param name="type">The type whose assembly name should be retrieved.</param>
    /// <returns>The name of the assembly associated with the provided type or the currently executing assembly.</returns>
    /// <exception cref="SecurityException">Thrown when a security error occurs while accessing the assembly.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when an error occurs while loading the assembly file.</exception>
    /// <exception cref="BadImageFormatException">Thrown when the assembly file has an invalid format.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when an error occurs while loading types in the assembly.</exception>
    public static string GetAssemblyName(Type? type)
    {
        if (type is null) return GetAssemblyName();
        try
        {
            return AssemblyNameByTypeCache.ContainsKey(type)
                ? AssemblyNameByTypeCache[type]
                : RegisterAssemblyNameInCache(type, GetAssembly(type));
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
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
        catch (ReflectionTypeLoadException)
        {
            ThrowError.ReflectionTypeLoadException();
        }

        return GetAssemblyName();
    }

    /// <summary>
    /// Gets the names of all loaded assemblies.
    /// </summary>
    /// <returns>An enumerable collection of assembly names.</returns>
    /// <exception cref="SecurityException">Thrown when a security error occurs while accessing the assemblies.</exception>
    /// <exception cref="FileNotFoundException">Thrown when an assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when an error occurs while loading an assembly file.</exception>
    /// <exception cref="BadImageFormatException">Thrown when an assembly file has an invalid format.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when an error occurs while loading types in an assembly.</exception>
    /// <exception cref="TypeLoadException">Thrown when a class cannot be loaded due to a type mismatch.</exception>
    /// <exception cref="MethodAccessException">Thrown when an attempt to access a method fails.</exception>
    /// <exception cref="InvalidOperationException">Thrown when an invalid operation occurs during the process.</exception>
    public static IEnumerable<string> GetAssembliesName()
    {
        try
        {
            return GetAllAssemblies().Select(assembly => assembly.GetName().Name!);
        }
        catch (SecurityException exception)
        {
            ThrowError.SecurityException(exception);
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
        catch (ReflectionTypeLoadException)
        {
            ThrowError.ReflectionTypeLoadException();
        }

        catch (TypeLoadException exception)
        {
            ThrowError.TypeLoadException(exception);
        }
        catch (MethodAccessException exception)
        {
            ThrowError.MethodAccessException(exception);
        }
        catch (InvalidOperationException exception)
        {
            ThrowError.InvalidOperationException(exception);
        }



        return default!;


    }

    /// <summary>
    /// Gets the name of the assembly associated with the provided object's type. If no object is provided or the object is null, it will retrieve the name of the currently executing assembly.
    /// </summary>
    /// <param name="object">The object whose type's assembly name should be retrieved.</param>
    /// <returns>The name of the assembly associated with the provided object's type or the currently executing assembly.</returns>
    /// <exception cref="SecurityException">Thrown when a security error occurs while accessing the assembly.</exception>
    /// <exception cref="FileNotFoundException">Thrown when the assembly file is not found.</exception>
    /// <exception cref="FileLoadException">Thrown when an error occurs while loading the assembly file.</exception>
    /// <exception cref="BadImageFormatException">Thrown when the assembly file has an invalid format.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when an error occurs while loading types in the assembly.</exception>
    public static string GetAssemblyName(object? @object) => @object is not null ? GetAssemblyName(@object.GetType()) : GetAssemblyName();

    #endregion

    #region Get Assembly Name Length

    /// <summary>
    /// Gets the length of the provided assembly name.
    /// </summary>
    /// <param name="assemblyName">The name of the assembly.</param>
    /// <returns>The length of the assembly name.</returns>
    public static int GetAssemblyNameLength(string assemblyName) => assemblyName.Length;

    /// <summary>
    /// Gets the length of the assembly name associated with the provided assembly type.
    /// </summary>
    /// <param name="assemblyType">The type whose assembly name's length should be retrieved.</param>
    /// <returns>The length of the assembly name associated with the provided assembly type.</returns>
    /// <remarks>
    /// The method will retrieve the assembly name based on the type of the provided assembly type.
    /// </remarks>
    /// <seealso cref="GetAssemblyName(Type)"/>
    public static int GetAssemblyNameLength(Type assemblyType) => GetAssemblyName(assemblyType).Length;

    /// <summary>
    /// Gets the length of the assembly name associated with the provided object's type.
    /// </summary>
    /// <param name="object">The object whose type's assembly name's length should be retrieved.</param>
    /// <returns>The length of the assembly name associated with the provided object's type.</returns>
    /// <remarks>
    /// If the provided object is not null, the method will return the assembly name length based on the type of the object.
    /// If the provided object is null or no object is provided, the method will retrieve the assembly name length of the currently executing assembly.
    /// </remarks>
    /// <seealso cref="GetAssemblyName(object)"/>
    public static int GetAssemblyNameLength(object @object) => GetAssemblyName(@object).Length;

    /// <summary>
    /// Gets the length of the assembly name associated with the provided assembly.
    /// </summary>
    /// <param name="assembly">The assembly whose name's length should be retrieved.</param>
    /// <returns>The length of the assembly name associated with the provided assembly.</returns>
    /// <seealso cref="GetAssemblyName(Assembly)"/>
    public static int GetAssemblyNameLength(Assembly assembly) => GetAssemblyName(assembly).Length;

    #endregion

    #region GetAllAssemblies

    /// <summary>
    /// Gets all the assemblies loaded in the current application domain or related to projects in the solution.
    /// </summary>
    /// <returns>An enumerable collection of assemblies.</returns>
    /// <remarks>
    /// This method attempts to retrieve assemblies from the current application domain and also from projects in the solution.
    /// If the assemblies have already been fetched and cached in the static variable, it will return the cached list.
    /// If not, it will attempt to find the solution file, parse its projects in order, and retrieve assemblies from each project.
    /// </remarks>
    /// <exception cref="FileNotFoundException">Thrown when the solution file or an assembly file is not found.</exception>
    /// <exception cref="InvalidOperationException">Thrown when an invalid operation occurs during the process.</exception>
    /// <exception cref="ReflectionTypeLoadException">Thrown when an error occurs while loading types in an assembly.</exception>
    /// <exception cref="Exception">Thrown for unexpected exceptions that occur during the process.</exception>
    public static IEnumerable<Assembly> GetAllAssemblies()
    {
        try
        {
            if (_allAssemblies != null && _allAssemblies.Any()) return _allAssemblies;

            var solutionFiles = SolutionFile
                .Parse(FindSolutionFile())
                .ProjectsInOrder
                .Select(x => x.ProjectName).ToList();

            _allAssemblies = solutionFiles.Select(GetAssembly);
        }

        catch (FileNotFoundException ex)
        {
            ThrowError.FileNotFoundException(ex);
        }
        catch (InvalidOperationException ex)
        {
            ThrowError.InvalidOperationException(ex);
        }
        catch (ReflectionTypeLoadException ex)
        {
            ThrowError.ReflectionTypeLoadException();
        }
        catch (Exception ex)
        {
            ThrowError.UnexpectedExceptions(ex);
        }
        return _allAssemblies!;
    }

    #endregion

    #region GetType

    /// <summary>
    /// Gets the types from the provided assembly that have names containing the specified type name.
    /// </summary>
    /// <param name="assembly">The assembly to search for types.</param>
    /// <param name="typeName">The name to match against the types.</param>
    /// <returns>An enumerable collection of types whose names contain the specified type name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided assembly is null.</exception>
    public static IEnumerable<Type> GeTypesByName(Assembly assembly, string typeName)
        => assembly.GetTypes().Where(v => v.FullName!.Contains(typeName));

    /// <summary>
    /// Gets the types from all loaded assemblies that have names containing the specified type name.
    /// </summary>
    /// <param name="typeName">The name to match against the types.</param>
    /// <returns>An enumerable collection of types whose names contain the specified type name.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided type name is null.</exception>
    public static IEnumerable<Type> GetTypesByName(string typeName)
    {
        List<Type> allTypes = new();
        var allAssembly = GetAllAssemblies();
        foreach (var types in allAssembly.Select(assembly => assembly.GetTypes().Where(v => v.FullName!.Contains(typeName))))
        {
            allTypes.AddRange(types);
        }

        return allTypes;
    }

    /// <summary>
    /// Gets all types from all assemblies.
    /// </summary>
    /// <returns>An enumerable collection of all types from all assemblies.</returns>
    public static IEnumerable<Type> GetTypes()
    {
        List<Type> allTypes = new();
        var allAssembly = GetAllAssemblies();
        foreach (Type[]? types in allAssembly.Select(assembly => assembly.GetTypes()))
        {
            allTypes.AddRange(types);
        }

        return allTypes;
    }

    /// <summary>
    /// Gets the first type from all  assemblies with the specified type name.
    /// </summary>
    /// <param name="typeName">The name of the type to retrieve.</param>
    /// <returns>The type with the specified name, or null if not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided type name is null.</exception>
    public static Type GetType(string typeName)
    {
        Type? type = null;
        foreach (var assemblyType in GetAllAssemblies().Select(assembly => assembly.GetType(typeName)).Where(assemblyType => assemblyType != null))
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

    //this method need try-catch
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



}