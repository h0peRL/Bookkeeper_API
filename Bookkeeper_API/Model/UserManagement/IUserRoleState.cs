namespace Bookkeeper_API.Model.UserManagement
{
    /// <summary>
    /// Interface for roles which helps manage the user's current role.
    /// </summary>
    public interface IUserRoleState
    {
        /// <summary>
        /// Uses state pattern to set another role.
        /// </summary>
        /// <param name="roleState">role to set.</param>
        public void SetRoleState(IUserRoleState roleState);

        /// <summary>
        /// Gets the string name of the role object.
        /// </summary>
        /// <returns>string containing role name.</returns>
        public string GetRoleName();
    }
}
