namespace Bookkeeper_API.Model.UserManagement
{
    public class User
    {
        private readonly int _id;
        private string _username;
        private string _passwordHash;
        private IUserRoleState _role;

        public User(int? id, string username, string passwordHash, IUserRoleState role)
        {
            _id = id;
            _username = username;
            _passwordHash = passwordHash;
            _role = role;
        }

        public void SetRole(IUserRoleState newRole)
        {
            _role.SetRoleState(newRole);
            // update database entry when implementing logic!
        }
    }
}
