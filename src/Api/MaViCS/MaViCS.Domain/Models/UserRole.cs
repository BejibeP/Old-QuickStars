namespace MaViCS.Domain.Models
{
    public static class UserRole
    {
        public enum UserRoleEnum
        {
            NoRole,
            Superviseur,
            User
        }

        public static string ToUserRoleString(this UserRoleEnum userRole)
        {
            string role = "";

            switch (userRole)
            {
                case UserRoleEnum.NoRole:
                    role = "NoRole";
                    break;
                case UserRoleEnum.Superviseur:
                    role = "Superviseur";
                    break;
                case UserRoleEnum.User:
                    role = "User";
                    break;
                default:
                    role = "NoRole";
                    break;
            }

            return role;
        }

    }
}
