namespace Bookkeeper_API.Model.UserManagement.RoleStates
{
    public class NewUserRoleState : IUserRoleState
    {
        private static readonly string _roleName = "new user";

        public string GetRoleName()
        {
            return _roleName;
        }

        public void SetRoleState(User user)
        {
            user.SetRole(new AuthorizedUserRoleState());
        }
    }
}
