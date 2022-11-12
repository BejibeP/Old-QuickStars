using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuickStars.MaViCS.Business.Dtos.Auth
{
    public class UserInfoDto
    {
        public string Id { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
