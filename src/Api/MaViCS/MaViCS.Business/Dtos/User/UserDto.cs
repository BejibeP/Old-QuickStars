﻿using static QuickStars.MaViCS.Domain.Security.UserHabilitation;

namespace QuickStars.MaViCS.Business.Dtos
{
    public class UserDto
    {

        public long Id { get; set; }

        public string Username { get; set; }

        public DateTime? LastLoggedOn { get; set; }

        public UserRole Role { get; set; }

        public bool ResetPassword { get; set; }

        public bool Enabled { get; set; }

    }
}
