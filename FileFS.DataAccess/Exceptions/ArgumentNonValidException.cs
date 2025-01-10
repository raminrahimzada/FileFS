namespace FileFS.DataAccess.Exceptions
{
    /// <summary>
    /// Exception that should be thrown when there is non valid argument value passed.
    /// </summary>
    public sealed class ArgumentNonValidException : FileFsException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNonValidException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ArgumentNonValidException(string message)
            : base(message)
        {
        }
    }
}