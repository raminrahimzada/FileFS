using System;

namespace FileFS.DataAccess.Exceptions
{
    /// <summary>
    /// Base exception for all known FileFS exceptions.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="FileFsException"/> class.
    /// </remarks>
    /// <param name="message">Exception message.</param>
    public abstract class FileFsException(string message) : Exception(message)
    {
    }
}