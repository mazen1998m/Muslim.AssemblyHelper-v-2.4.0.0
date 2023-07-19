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

The method returns the Assembly that contains the specified type or the Assembly of the currently executing code if the type is null.
If there are any of the exceptions listed in the Exceptions section, they will be returned Assembly of the currently executing code

#### Exceptions

The method may throw the following exceptions:

- SecurityException
- TypeLoadException
- ReflectionTypeLoadException
- FileNotFoundException
- FileLoadException
- BadImageFormatException
- InvalidOperationException

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

//and more...

```

In this example, we demonstrate how to handle the exceptions that may be thrown by the GetAssembly method. We create a try-catch block and catch each specific exception type individually. You can replace the comment placeholders with your own exception handling code.

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

- SecurityException
- PathTooLongException
- FileNotFoundException
- FileLoadException
- BadImageFormatException
- ArgumentException
- InvalidOperationException

#### Examples

##### Example 1:

```csharp
// Get the executing assembly
var assembly = GetAssembly(null);
```

In this example, the GetAssembly method is called with a null value for the assemblyName parameter.
This means that no specific assembly name is provided, and the method will return the executing assembly.
The retrieved assembly is then assigned to the assembly variable for further processing.

##### Example 2:

```csharp
// Get an assembly by name
var assembly = GetAssembly("MyAssembly");
```

In this example, the GetAssembly method is called with the assembly name "MyAssembly" as the assemblyName parameter. The method attempts to retrieve the assembly with the specified name. If the assembly is found, it is assigned to the assembly variable for further processing.

If any exception occurs, the method will assign the executing assembly to the assembly variable by default. Alternatively, you can handle the exception accordingly.

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

### GetAssembly Method

This method retrieves the Assembly instance of the code that calls it. It is used to get the Assembly object representing the currently executing code. If the retrieval is successful, the method returns the Assembly object. However, if any exceptions occur during the process, the method will call corresponding custom error methods and return a null reference.

#### Method Signature

```csharp
public static Assembly GetAssembly()
```

#### Parameters
This method does not take any parameters.

#### Return Value

Assembly: The Assembly of the currently executing code if successful.
null: If any exceptions occur during the process.

#### Exceptions
FileNotFoundException
BadImageFormatException
SecurityException
FileLoadException
Exception

#### Examples

##### Example 1:

```csharp
// Example code demonstrating the usage of GetAssembly method
Assembly assembly = GetAssembly();
if (assembly != null)
{
    // Perform actions with the assembly
}
```
In this example, the GetAssembly method is called to obtain the Assembly object representing the currently executing code. If the retrieval is successful and the assembly object is not null, you can proceed to perform actions using the assembly object.

##### Example 2:

```csharp
// Example code demonstrating exception handling with GetAssembly method
try
{
    Assembly assembly = GetAssembly();
    if (assembly != null)
    {
        // Perform actions with the assembly
    }
}
catch (FileNotFoundException ex)
{
    // Handle FileNotFoundException
}
catch (BadImageFormatException ex)
{
    // Handle BadImageFormatException
}
catch (SecurityException ex)
{
    // Handle SecurityException
}
catch (FileLoadException ex)
{
    // Handle FileLoadException
}
catch (Exception ex)
{
    // Handle other unexpected exceptions
}

```
This example demonstrates exception handling with the GetAssembly method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assembly object. You can handle each exception type separately and implement the necessary error-handling logic for each case.

### GetAssembly Method

#### Method Signature

```csharp
public static Assembly GetAssembly(object? @object)
```

#### Parameters
@object (optional): The object whose type's Assembly needs to be retrieved.
#### Return Value

#### Exceptions

#### Examples

##### Example 1:

```csharp
// Create an object of a specific type
MyClass myObject = new MyClass();

// Retrieve the Assembly object associated with the object's type
Assembly objectAssembly = GetAssembly(myObject);
if (objectAssembly != null)
{
    // Perform actions with the object's type assembly
    // ...
}
```
In this example, the GetAssembly method is called with an object parameter to retrieve the Assembly object associated with the specified object's type. If the retrieval is successful and the objectAssembly object is not null, you can proceed to perform actions using the assembly object.

##### Example 2:

```csharp
try
{
    // Retrieve the Assembly object for the currently executing code or the Assembly associated with the specified object's type
    Assembly assembly = GetAssembly(myObject);
    if (assembly != null)
    {
        // Perform actions with the assembly
        // ...
    }
}
catch (SecurityException ex)
{
    // Handle SecurityException: security violation occurred
    // ...
}
catch (TypeLoadException ex)
{
    // Handle TypeLoadException: specified type cannot be loaded
    // ...
}
catch (ReflectionTypeLoadException ex)
{
    // Handle ReflectionTypeLoadException: error loading types from an assembly
    // ...
}
catch (FileNotFoundException ex)
{
    // Handle FileNotFoundException: assembly file not found
    // ...
}
catch (FileLoadException ex)
{
    // Handle FileLoadException: assembly cannot be loaded
    // ...
}
catch (BadImageFormatException ex)
{
    // Handle BadImageFormatException: assembly is not a valid image format
    // ...
}
catch (InvalidOperationException ex)
{
    // Handle InvalidOperationException: invalid operation
    // ...
}

```



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
