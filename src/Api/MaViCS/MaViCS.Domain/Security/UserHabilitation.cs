namespace QuickStars.MaViCS.Domain.Security
{
    public static class UserHabilitation
    {
        public enum UserRoleEnum
        {
            None,
            User,
            Administrator
        }

        public class UserRole : IEquatable<UserRole?>
        {

            public static UserRole None { get { return new UserRole("None"); } }
            public static UserRole User { get { return new UserRole("User"); } }
            public static UserRole Administrator { get { return new UserRole("Administrator"); } }

            public string Name { get; private set; }

            public UserRole(string name)
            {
                Name = name;
            }

            public override bool Equals(object? obj)
            {
                return Equals(obj as UserRole);
            }

            public bool Equals(UserRole? other)
            {
                return other is not null &&
                       Name == other.Name;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Name);
            }

            public static bool operator ==(UserRole? left, UserRole? right)
            {
                return EqualityComparer<UserRole>.Default.Equals(left, right);
            }

            public static bool operator !=(UserRole? left, UserRole? right)
            {
                return !(left == right);
            }

        }

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