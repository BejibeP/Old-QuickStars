namespace MaViCS.Domain.Framework.Habilitation
{
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
}