using Microsoft.AspNetCore.Identity;

namespace Chat.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.FriendsList = new List<ApplicationUser>();
            this.BlackList = new List<ApplicationUser>();
        }
        public ICollection<ApplicationUser> FriendsList { get; set; }
        public ICollection<ApplicationUser> BlackList { get; set; }
        public bool IsOnline { get; set; }
    }
}
