# Assembly Helper Utility

The Assembly Helper Utility is a .NET utility class that provides convenient methods for working with assemblies. It simplifies tasks such as retrieving assembly information, finding solution files, and getting types from assemblies.

## Features

### GetAssembly(Type? type) Method

The GetAssembly method is used to retrieve the assembly that contains a specified type. If no type is provided, it returns the assembly that represents the currently executing code.

#### Method Signature

```csharp
public static Assembly GetAssembly(Type? type)
```

#### Parameters

type (optional): The type whose assembly to retrieve.

#### Return Value

The method returns the assembly that contains the specified type or the assembly representing the currently executing code.

#### Exceptions

The method may throw the following exceptions:

- SecurityException: Thrown when there is a security error.
- TypeLoadException: Thrown when a type cannot be loaded.
- ReflectionTypeLoadException: Thrown when there is an error loading types.
- FileNotFoundException: Thrown when the assembly file is not found.
- BadImageFormatException : Thrown when assembly is not a valid assembly or assembly is targeted for a different version of the runtime.
- FileLoadException : Thrown when the assembly is found but cannot be loaded due to an error in the file format or a mismatch in the processor architecture.

#### Examples

##### Example 1: Retrieving the Assembly for a Type

```csharp
Type myType = typeof(MyClass);
Assembly assembly = GetAssembly(myType);

```

In this example, we retrieve the assembly that contains the MyClass type by passing typeof(MyClass) as the type parameter to the GetAssembly method. The returned assembly is then assigned to the assembly variable.

##### Example 2: Retrieving the Currently Executing Assembly

```csharp
Assembly currentAssembly = GetAssembly(null);

```

In this example, we don't provide a type parameter to the GetAssembly method, so it returns the assembly representing the currently executing code. The returned assembly is then assigned to the currentAssembly variable.

##### Example 3: Handling Exceptions

```csharp
try
{
    Type nullType = null;
    Assembly assembly = GetAssembly(nullType);
    // Process the assembly
}
catch (NullReferenceException)
{
    // Handle null reference exception
}
catch (SecurityException)
{
    // Handle security exception
}

catch (TypeLoadException)
{
    // Handle type load exception
}
catch (ReflectionTypeLoadException)
{
    // Handle reflection type load exception
}

```

In this example, we demonstrate how to handle the exceptions that may be thrown by the GetAssembly method. We create a try-catch block and catch each specific exception type individually. You can replace the comment placeholders with your own exception handling code.

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetAssembly(string assemblyName) Method

The GetAssembly method is used to retrieve an assembly based on the provided assembly name.

#### Method Signature

```csharp
public static Assembly GetAssembly(string? assemblyName)
```

#### Parameters

assemblyName (string?): The name of the assembly to retrieve. It can be null or empty to return the executing assembly.

#### Return Value

Assembly: The retrieved assembly based on the provided assembly name. If no assembly name is provided or if any exceptions occur during the retrieval process, the method returns the executing assembly.

#### Exceptions

The GetAssembly method may throw the following exceptions:

- SecurityException: Thrown when there is a security violation during the assembly load process.
- PathTooLongException: Thrown when the specified assembly name exceeds the maximum supported path length.
- FileNotFoundException: Thrown when the specified assembly file is not found.
- FileLoadException: Thrown when an error occurs while loading the assembly file.
- BadImageFormatException: Thrown when the assembly file format is invalid or unsupported.
- ArgumentException: Thrown when the provided assembly name is invalid or empty.
- InvalidOperationException: Thrown when an invalid operation occurs during the assembly load process.

#### Examples

##### Example 1:

```csharp
// Get the executing assembly
var assembly = GetAssembly(null);
```

In this example, the GetAssembly method is called with a null value for the assemblyName parameter.
This means that no specific assembly name is provided, and the method will return the executing assembly.
The retrieved assembly is then assigned to the assembly variable for further processing.

This example is useful when you need to work with the currently executing assembly without explicitly specifying its name.

##### Example 2:

```csharp
// Get an assembly by name
var assembly = GetAssembly("MyAssembly");
```

In this example, the GetAssembly method is called with the assembly name "MyAssembly" as the assemblyName parameter. The method attempts to retrieve the assembly with the specified name. If the assembly is found, it is assigned to the assembly variable for further processing.

If the assembly is not found or if any exception occurs, the method will assign the executing assembly to the assembly variable by default. Alternatively, you can handle the exception accordingly.

This example is useful when you are aware of the name of the assembly you want to retrieve and need to work with it specifically.

##### Example 3:

```csharp
try
{
    // Attempt to retrieve the assembly by name
    var assembly = GetAssembly("MyAssembly");

    // Process the retrieved assembly
    // ...
}
catch (SecurityException ex)
{
    Console.WriteLine("SecurityException occurred: " + ex.Message);
    // Handle the SecurityException
}
catch (PathTooLongException ex)
{
    Console.WriteLine("PathTooLongException occurred: " + ex.Message);
    // Handle the PathTooLongException
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("FileNotFoundException occurred: " + ex.Message);
    // Handle the FileNotFoundException
}
catch (FileLoadException ex)
{
    Console.WriteLine("FileLoadException occurred: " + ex.Message);
    // Handle the FileLoadException
}
catch (BadImageFormatException ex)
{
    Console.WriteLine("BadImageFormatException occurred: " + ex.Message);
    // Handle the BadImageFormatException
}
catch (ArgumentException ex)
{
    Console.WriteLine("ArgumentException occurred: " + ex.Message);
    // Handle the ArgumentException
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("InvalidOperationException occurred: " + ex.Message);
    // Handle the InvalidOperationException
}

```

In this example, the GetAssembly method is called with the assembly name "MyAssembly". If any exceptions occur during the execution of the method, they are caught in separate catch blocks based on the type of exception. You can customize the exception handling code within each catch block to suit your specific requirements.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetAssemblyName Method

Retrieves the names of all assemblies in the solution.

#### Method Signature

```csharp
public static List<string> GetAssemblyName()
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetAssemblyName(Type type) Method

Retrieves the names of all assemblies in the solution.

#### Method Signature

```csharp
public static string GetAssemblyName(Type type)
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetAssemblyNameLength(string assemblyName) Method

#### Method Signature

```csharp
 public static int GetAssemblyNameLength(string assemblyName)
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetAssemblyNameLength(Type assemblyType) Method

#### Method Signature

```csharp
public static int GetAssemblyNameLength(Type assemblyType)
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetAllAssembly Method

#### Method Signature

```csharp
public static List<Assembly> GetAllAssembly()
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GeTypeByName(Assembly assembly, string typeName) Method

#### Method Signature

```csharp
public static IEnumerable<Type> GeTypeByName(Assembly assembly, string typeName)
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GeTypeByName(string typeName) Method

#### Method Signature

```csharp
public static IEnumerable<Type> GeTypeByName(string typeName)
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetTypes Method

#### Method Signature

```csharp
public static IEnumerable<Type> GetTypes()
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetType Method

#### Method Signature

```csharp
public static Type GetType(string typeName)
```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

### GetConstructors Method

#### Method Signature

```csharp

```

#### Parameters

#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp

```

##### Example 2:

```csharp

```

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

## Usage

To use the Assembly Helper Utility in your .NET project, make sure to include the following namespaces at the beginning of your code file:

```csharp
using Microsoft.Build.Construction;
using System.Reflection;
```

## Example:

```csharp
using AssemblyServices;
using Microsoft.Build.Construction;
using System.Reflection;

// Retrieve the assembly containing a specific type
Assembly assembly = AssemblyServices.GetAssembly(typeof(MyType));

// Retrieve all assembly names in the solution
List<string> assemblyNames = AssemblyServices.GetAssemblyName();

// Get types from all assemblies containing a specific type name
IEnumerable<Type> types = AssemblyServices.GeTypeByName("MyType");

// Retrieve all types in the solution
IEnumerable<Type> allTypes = AssemblyServices.GetTypes();

// ...and more

```

## Contributing

Contributions are welcome! If you have any suggestions, bug reports, or feature requests, please feel free to open an issue or submit a pull request.

## License

This utility class is licensed under the MIT License.
