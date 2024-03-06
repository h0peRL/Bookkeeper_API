namespace Bookkeeper_API.Model.UserManagement
{
    public class User
    {
        public User(int? id, string username, string passwordHash, IUserRoleState role)
        {
            Id = id;
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// The Entity Framework requires an empty constructor. Please do not remove it.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private User()
        {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int? Id { get; private set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; }

        public IUserRoleState Role { get; private set; }

        public void SetRole(IUserRoleState newRole)
        {
            Role = newRole;
        }
    }
}
