namespace MaViCS.Domain.Framework.Habilitation
{
    public static class UserRoleExtensions
    {

        public static UserRoleEnum ToEnum(this UserRole userRole)
        {
            if (userRole == UserRole.User) return UserRoleEnum.User;
            if (userRole == UserRole.Administrator) return UserRoleEnum.Administrator;

            return UserRoleEnum.None;
        }

        public static UserRole ToUserRole(this UserRoleEnum userRoleEnum)
        {
            switch (userRoleEnum)
            {
                case UserRoleEnum.User:
                    return UserRole.User;
                case UserRoleEnum.Administrator:
                    return UserRole.Administrator;
                default:
                    return UserRole.None;
            }
        }

    }
}