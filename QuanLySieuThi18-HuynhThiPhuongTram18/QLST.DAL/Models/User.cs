using System;
using System.Collections.Generic;

#nullable disable

namespace QLST.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
