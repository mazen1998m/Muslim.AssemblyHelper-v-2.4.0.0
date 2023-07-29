# Assembly Helper Utility

The Assembly Helper Utility is a .NET utility class that provides convenient methods for working with assemblies. It simplifies tasks such as retrieving assembly information, finding solution files, and getting types from assemblies.

## Features

### GetAssembly() Method

#### Description

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

### GetAssembly(Type? type) Method

#### Description

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

##### Example 2: Handling Exceptions

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

#### Description

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
// Get an assembly by name
var assembly = GetAssembly("MyAssembly");
```

In this example, the GetAssembly method is called with the assembly name "MyAssembly" as the assemblyName parameter. The method attempts to retrieve the assembly with the specified name. If the assembly is found, it is assigned to the assembly variable for further processing.

If any exception occurs, the method will assign the executing assembly to the assembly variable by default. Alternatively, you can handle the exception accordingly.

This example is useful when you are aware of the name of the assembly you want to retrieve and need to work with it specifically.

##### Example 2:

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

### GetAssembly(object? @object) Method

#### Description

Gets the Assembly of the currently executing code or the Assembly associated with the specified object's type.

#### Method Signature

```csharp
public static Assembly GetAssembly(object? @object)
```

#### Parameters

@object (optional): The object whose type's Assembly needs to be retrieved.

#### Return Value

#### Exceptions

The GetAssembly method may throw the following exceptions:

- SecurityException
- TypeLoadException
- ReflectionTypeLoadException
- FileNotFoundException
- FileLoadException
- BadImageFormatException
- InvalidOperationException

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

### GetAssemblyName() Method

#### Description

This method retrieves the name of the loaded assembly.

#### Method Signature

```csharp
public static string GetAssemblyName()

```

#### Parameters

This method does not take any parameters.

#### Return Value

string: The name of the loaded assembly as a string.

#### Exceptions

This method may throw the following exceptions:

- SecurityException:
- FileNotFoundException:
- FileLoadException:
- BadImageFormatException:
- ReflectionTypeLoadException:

#### Examples

##### Example 1:

```csharp
// Use the loaded assembly name in your application logic
 string assemblyName = GetAssemblyName();
```

In this example, we call the GetAssemblyName() method to retrieve the name of the loaded assembly.

##### Example 2:

```csharp
try
{
    string assemblyName = GetAssemblyName();
    Console.WriteLine($"Loaded assembly name: {assemblyName}");
}
catch (SecurityException ex)
{
    Console.WriteLine($"Security Exception: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File Not Found Exception: {ex.Message}");
}
catch (FileLoadException ex)
{
    Console.WriteLine($"File Load Exception: {ex.Message}");
}
catch (BadImageFormatException ex)
{
    Console.WriteLine($"Bad Image Format Exception: {ex.Message}");
}
catch (ReflectionTypeLoadException)
{
    Console.WriteLine("Reflection Type Load Exception: Error occurred while loading types in the assembly.");
}

```

This example demonstrates exception handling with the GetAssemblyName method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assembly name. You can handle each exception type separately and implement the necessary error-handling logic for each case.

Note: In the examples, make sure to replace the Console.WriteLine() statements with appropriate error handling or application logic based on your use case.

### GetAssemblyName(Assembly? assembly) Method

#### Description

This method retrieves the name of the provided loaded assembly or the currently executing assembly if no assembly is provided.

#### Method Signature

```csharp
public static string GetAssemblyName(Assembly? assembly)

```

#### Parameters

assembly: The loaded assembly from which to retrieve the name.

#### Return Value

string: The name of the provided assembly or the currently executing assembly as a string.

#### Exceptions

This method may throw the following exceptions:

- SecurityException:
- FileNotFoundException:
- FileLoadException:
- BadImageFormatException:
- ReflectionTypeLoadException:

#### Examples

##### Example 1:

```csharp
    Assembly someOtherAssembly = // Load an assembly from another source or location
    string assemblyName = GetAssemblyName(someOtherAssembly);
```

In this example, we load an assembly someOtherAssembly from a different source or location. We then call the GetAssemblyName() method, passing someOtherAssembly as the parameter. The method returns the name of the loaded assembly, which can be used in your application logic.

##### Example 2:

```csharp
try
{
    Assembly executingAssembly = Assembly.GetExecutingAssembly();
    string assemblyName = GetAssemblyName(executingAssembly);
    Console.WriteLine($"Loaded assembly name: {assemblyName}");
}
catch (SecurityException ex)
{
    Console.WriteLine($"Security Exception: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File Not Found Exception: {ex.Message}");
}
catch (FileLoadException ex)
{
    Console.WriteLine($"File Load Exception: {ex.Message}");
}
catch (BadImageFormatException ex)
{
    Console.WriteLine($"Bad Image Format Exception: {ex.Message}");
}
catch (ReflectionTypeLoadException)
{
    Console.WriteLine("Reflection Type Load Exception: Error occurred while loading types in the assembly.");
}


```

This example demonstrates exception handling with the GetAssemblyName method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assembly name. You can handle each exception type separately and implement the necessary error-handling logic for each case.

Note: In the examples, make sure to replace the Console.WriteLine() statements with appropriate error handling or application logic based on your use case.

### GetAssemblyName(Type? type) Method

#### Description

This method retrieves the name of the assembly associated with the provided Type or the currently executing assembly if no Type is provided.

#### Method Signature

```csharp
public static string GetAssemblyName(Type? type)

```

#### Parameters

type : The Type whose assembly name should be retrieved.

#### Return Value

string: The name of the assembly associated with the provided Type or the currently executing assembly as a string.

#### Exceptions

This method may throw the following exceptions:

- SecurityException:
- FileNotFoundException:
- FileLoadException:
- BadImageFormatException:
- ReflectionTypeLoadException:

#### Examples

##### Example 1:

```csharp
   Type someType = typeof(SomeClass);
    string assemblyName = GetAssemblyName(someType);
    Console.WriteLine($"Assembly name associated with {someType.Name}: {assemblyName}");
```

In this example, we have a Type called someType, which represents a particular class (e.g., SomeClass). We call the GetAssemblyName() method, passing someType as the parameter. The method retrieves the name of the assembly associated with someType and displays it using Console.WriteLine().

##### Example 2:

```csharp
try
{
    Type someType = typeof(SomeClass);
    string assemblyName = GetAssemblyName(someType);
    Console.WriteLine($"Assembly name associated with {someType.Name}: {assemblyName}");
}
catch (SecurityException ex)
{
    Console.WriteLine($"Security Exception: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"File Not Found Exception: {ex.Message}");
}
catch (FileLoadException ex)
{
    Console.WriteLine($"File Load Exception: {ex.Message}");
}
catch (BadImageFormatException ex)
{
    Console.WriteLine($"Bad Image Format Exception: {ex.Message}");
}
catch (ReflectionTypeLoadException)
{
    Console.WriteLine("Reflection Type Load Exception: Error occurred while loading types in the assembly.");
}


```

This example demonstrates exception handling with the GetAssemblyName method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assembly name. You can handle each exception type separately and implement the necessary error-handling logic for each case.

Note: In the examples, make sure to replace the Console.WriteLine() statements with appropriate error handling or application logic based on your use case.

### GetAssemblyName(object? @object) Method

#### Description

This method retrieves the name of the assembly associated with the provided object's type. If no object is provided or the object is null, it will retrieve the name of the currently executing assembly.

#### Method Signature

```csharp
public static string GetAssemblyName(object? @object)


```

#### Parameters

object: The object whose type's assembly name should be retrieved.

#### Return Value

A string representing the name of the assembly associated with the provided object's type or the currently executing assembly.

#### Exceptions

This method may throw the following exceptions:

- SecurityException
- FileNotFoundException
- FileLoadException
- BadImageFormatException
- ReflectionTypeLoadException

#### Examples

##### Example 1:

```csharp
    SomeClass obj = new SomeClass();
    string assemblyName = GetAssemblyName(obj);
    Console.WriteLine("Assembly Name: " + assemblyName);
```

In this example, we retrieve the assembly that contains the SomeClass obj by passing obj as the a parameter to the GetAssemblyName method. The returned assembly name is then assigned to the assemblyName variable.

##### Example 2:

```csharp
try
{
    SomeClass obj = new SomeClass();
    string assemblyName = GetAssemblyName(obj);
}
catch (SecurityException ex)
{
    // Handle SecurityException
}
catch (FileNotFoundException ex)
{
    // Handle FileNotFoundException
}
catch (FileLoadException ex)
{
    // Handle FileLoadException
}
catch (BadImageFormatException ex)
{
    // Handle BadImageFormatException
}
catch (ReflectionTypeLoadException ex)
{
    // Handle ReflectionTypeLoadException
}


```

This example demonstrates exception handling with the GetAssemblyName method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assembly name. You can handle each exception type separately and implement the necessary error-handling logic for each case.

Note: In the examples, make sure to replace the Console.WriteLine() statements with appropriate error handling or application logic based on your use case.

### GetAssembliesName() Method

#### Description

This method retrieves the names of all assemblies in the current application .

#### Method Signature

```csharp
public static IEnumerable<string> GetAssembliesName()

```

#### Parameters

None

#### Return Value

An enumerable collection of strings representing the names of assemblies

#### Exceptions

This method may throw the following exceptions:

- SecurityException
- FileNotFoundException
- FileLoadException
- BadImageFormatException
- ReflectionTypeLoadException
- TypeLoadException
- MethodAccessException
- InvalidOperationException

#### Examples

##### Example 1:

```csharp
    IEnumerable<string> assemblyNames = GetAssembliesName();
```

In this example, we call the GetAssembliesName() method, The method retrieves the names
of all assemblies in the current application

##### Example 2:

```csharp
try
{
    IEnumerable<string> assemblyNames = GetAssembliesName();
    foreach (string assemblyName in assemblyNames)
    {
        Console.WriteLine(assemblyName);
    }
}
catch (SecurityException ex)
{
    // Handle SecurityException
}
catch (FileNotFoundException ex)
{
    // Handle FileNotFoundException
}
catch (FileLoadException ex)
{
    // Handle FileLoadException
}
catch (BadImageFormatException ex)
{
    // Handle BadImageFormatException
}
catch (ReflectionTypeLoadException)
{
    // Handle ReflectionTypeLoadException
}
catch (TypeLoadException ex)
{
    // Handle TypeLoadException
}
catch (MethodAccessException ex)
{
    // Handle MethodAccessException
}
catch (InvalidOperationException ex)
{
    // Handle InvalidOperationException
}


```

This example demonstrates exception handling with the GetAssembliesName method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assemblies name. You can handle each exception type separately and implement the necessary error-handling logic for each case.

Note: In the examples, make sure to replace the Console.WriteLine() statements with appropriate error handling or application logic based on your use case.

### GetAssemblyNameLength(string assemblyName) Method

#### Description

This method retrieves the length of the provided assembly name.

#### Method Signature

```csharp
public static int GetAssemblyNameLength(string assemblyName)

```

#### Parameters

assemblyName: The name of the assembly for which the length is to be calculated

#### Return Value

An integer representing the length of the provided assembly name.

#### Exceptions

None

#### Examples

##### Example 1:

```csharp
   string assemblyName = "MyAssemblyName";
    int length = GetAssemblyNameLength(assemblyName);
    Console.WriteLine("Assembly Name Length: " + length);
```

### GetAssemblyNameLength(Type assemblyType) Method

#### Description

This method gets the length of the assembly name associated with the provided assembly type.

#### Method Signature

```csharp
public static int GetAssemblyNameLength(Type assemblyType)

```

#### Parameters

assemblyType: The type whose assembly name's length should be retrieved.

#### Return Value

An integer representing the length of the assembly name associated with the provided assembly type.

#### Remarks

The method will retrieve the assembly name based on the type of the provided assembly type.

See Also
GetAssemblyName(Type): Another method in this class that retrieves the assembly name based on the provided assembly type.

#### Exceptions

same GetAssemblyName(Type) Exceptions

#### Examples

##### Example 1:

```csharp
    Type myType = typeof(MyClass);
    int length = GetAssemblyNameLength(myType);
    Console.WriteLine("Assembly Name Length: " + length);
```

### GetAssemblyNameLength(object @object) Method

#### Description

This method gets the length of the assembly name associated with the provided object's type.

#### Method Signature

```csharp
public static int GetAssemblyNameLength(object @object)

```

#### Parameters

object: The object whose type's assembly name's length should be retrieved.

#### Return Value

An integer representing the length of the assembly name associated with the provided object's type.

#### Remarks

- If the provided object is not null, the method will return the assembly name length based on the type of the object.
- If the provided object is null or no object is provided, the method will retrieve the assembly name length of the currently executing assembly.

See Also
GetAssemblyName(object): Another method in this class that retrieves the assembly name based on the provided object's type.

#### Exceptions

same GetAssemblyName(object) Exceptions

#### Examples

##### Example 1:

```csharp
   SomeClass obj = new SomeClass();
    int length = GetAssemblyNameLength(obj);
    Console.WriteLine("Assembly Name Length: " + length);
```

### GetAssemblyNameLength(Assembly assembly) Method

#### Description

This method gets the length of the assembly name associated with the provided assembly.

#### Method Signature

```csharp
public static int GetAssemblyNameLength(Assembly assembly)


```

#### Parameters

assembly: The assembly whose name's length should be retrieved.

#### Return Value

An integer representing the length of the assembly name associated with the provided assembly.

#### Remarks

See Also
GetAssemblyName(Assembly): Another method in this class that retrieves the assembly name based on the provided assembly.

#### Exceptions

same GetAssemblyName(Assembly) Exceptions

#### Examples

##### Example 1:

```csharp
    Assembly myAssembly = Assembly.GetExecutingAssembly();
    int length = GetAssemblyNameLength(myAssembly);
    Console.WriteLine("Assembly Name Length: " + length);
```

### GetAllAssemblies() Method

#### Description

This method retrieves all the assemblies loaded in the current application domain or related to projects in the solution.

#### Method Signature

```csharp
public static IEnumerable<Assembly> GetAllAssemblies()

```

#### Parameters

None

#### Return Value

An enumerable collection of assemblies.

##### Remarks

- This method attempts to retrieve assemblies from the current application domain and also from projects in the solution.
- If the assemblies have already been fetched and cached in the static variable, it will return the cached list.
- If not, it will attempt to find the solution file, parse its projects in order, and retrieve assemblies from each project.

#### Exceptions

This method may throw the following exceptions:

- Exception
- FileNotFoundException
- ReflectionTypeLoadException
- InvalidOperationException

#### Examples

##### Example 1:

```csharp
    IEnumerable<Assembly> assemblies = GetAllAssemblies();
    foreach (var assembly in assemblies)
    {
        Console.WriteLine(assembly.FullName);
    }
```

##### Example 2:

```csharp
try
{
    IEnumerable<Assembly> assemblies = GetAllAssemblies();
    foreach (var assembly in assemblies)
    {
        Console.WriteLine(assembly.FullName);
    }
}
catch (FileNotFoundException ex)
{
    // Handle FileNotFoundException
}
catch (InvalidOperationException ex)
{
    // Handle InvalidOperationException
}
catch (ReflectionTypeLoadException ex)
{
    // Handle ReflectionTypeLoadException
}
catch (Exception ex)
{
    // Handle any unexpected exceptions that might occur during the process.
}



```

This example demonstrates exception handling with the GetAllAssemblies method. The method is called within a try-catch block to catch specific exceptions that may occur during the retrieval of the assemblies name. You can handle each exception type separately and implement the necessary error-handling logic for each case.

Note: In the examples, make sure to replace the comment with appropriate error handling or application logic based on your use case.

### GetTypesByName(Assembly assembly, string typeName) Method

#### Description

This method gets the types from the provided assembly that have names containing the specified type name.

#### Method Signature

```csharp
public static IEnumerable<Type> GetTypesByName(Assembly assembly, string typeName)

```

#### Parameters

assembly: The assembly to search for types. It must not be null.
typeName: The name to match against the types.

#### Return Value

An enumerable collection of types whose names contain the specified type name.

#### Exceptions

The method may throw the following exception:

- ArgumentNullException

#### Examples

##### Example 1:

```csharp
try
{
    Assembly myAssembly = Assembly.GetExecutingAssembly(); // Get the currently executing assembly.
    string searchName = "Controller"; // The name to search for in type names.

    IEnumerable<Type> types = GetTypesByName(myAssembly, searchName);

    foreach (Type type in types)
    {
        Console.WriteLine(type.FullName);
    }
}
catch (ArgumentNullException ex)
{
    // Handle ArgumentNullException
}

```

### GetTypesByName(string typeName) Method

#### Description

This method gets the types from all loaded assemblies that have names containing the specified type name.

#### Method Signature

```csharp

public static IEnumerable<Type> GetTypesByName(string typeName)
```

#### Parameters

typeName: The name to match against the types. It must not be null.

#### Return Value

An enumerable collection of types whose names contain the specified type name.

#### Exceptions

The method may throw the following exception:

- ArgumentNullException

#### Examples

##### Example 1:

```csharp
try
{
    string searchName = "Controller"; // The name to search for in type names.

    IEnumerable<Type> types = GetTypesByName(searchName);

    foreach (Type type in types)
    {
        Console.WriteLine(type.FullName);
    }
}
catch (ArgumentNullException ex)
{
    // Handle ArgumentNullException
}


```

### GetTypes() Method

#### Description

This method gets all types from all assemblies that are currently loaded in the application domain.

#### Method Signature

```csharp

public static IEnumerable<Type> GetTypes()

```

#### Parameters

None

#### Return Value

An enumerable collection of all types from all assemblies.

#### Examples

##### Example 1:

```csharp
// Code snippet demonstrating how to use GetTypes method.
try
{
    IEnumerable<Type> allTypes = GetTypes();

    foreach (Type type in allTypes)
    {
        Console.WriteLine(type.FullName);
    }
}
catch (Exception ex)
{
    // Handle any exceptions that might occur during the process.
}


```

### GetType(string typeName) Method

#### Description

This method gets the first type from all assemblies with the specified type name.

#### Method Signature

```csharp

public static Type GetType(string typeName)


```

#### Parameters

typeName: The name of the type to retrieve. It must not be null.

#### Return Value

The type with the specified name, or null if not found.

#### Exceptions

The method may throw the following exception:

- ArgumentNullException

#### Examples

##### Example 1:

```csharp
try
{
    string typeName = "MyNamespace.MyClass"; // The fully qualified name of the type to retrieve.

    Type type = GetType(typeName);

    if (type != null)
    {
        Console.WriteLine("Type Found: " + type.FullName);
    }
    else
    {
        Console.WriteLine("Type Not Found.");
    }
}
catch (ArgumentNullException ex)
{
    // Handle ArgumentNullException
}


```

## Contributing

Contributions are welcome! If you have any suggestions, bug reports, or feature requests, please feel free to open an issue or submit a pull request.

## License

This utility class is licensed under the MIT License.
