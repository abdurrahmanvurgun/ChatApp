

using Microsoft.AspNetCore.Identity;

namespace ChatAppClient.Models
{
    public class User:IdentityUser
    {
        public int UserId { get; set; }
    }
}
