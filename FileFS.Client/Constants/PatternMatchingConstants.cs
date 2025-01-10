namespace FileFS.Client.Constants
{
    /// <summary>
    /// sealed class containing pattern matching constants.
    /// </summary>
    public sealed class PatternMatchingConstants
    {
        /// <summary>
        /// Pattern that represents valid filename for FileFS storage.
        /// </summary>
        public static readonly string ValidFilename = @"^(\/|(\/[\p{L}\-_. 0-9]+)+)$";
    }
}