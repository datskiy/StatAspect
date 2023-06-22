namespace StatAspect.Domain._Core.Authentication.Aggregates
{
    /// <summary>
    /// XXX
    /// </summary>
    public sealed class UserCredentials
    {
        /// <summary>
        /// XXX
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// XXX
        /// </summary>
        public string PasswordHash { get; }

        /// <summary>
        /// XXX
        /// </summary>
        public UserCredentials(string username, string passwordHash) // TODO: implement
        {
            Username = username;
            PasswordHash = passwordHash;
        }
    }
}