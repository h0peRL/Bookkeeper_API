namespace Bookkeeper_API.Model.UserManagement.RoleStates
{
    public class AuthorizedUserRoleState : IUserRoleState
    {
        private static readonly string _roleName = "authorized user";

        public string GetRoleName()
        {
            return _roleName;
        }

        public void SetRoleState(User user)
        {
            throw new NotImplementedException();
        }
    }
}
