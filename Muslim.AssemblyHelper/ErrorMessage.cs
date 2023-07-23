namespace Muslim.AssemblyHelper;

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
    public const string MethodAccessException = $"An error occurred: {nameof(MethodAccessException)}. Please check the accessibility of the method.";
    public const string UnexpectedException = "An unexpected error occurred.";
}