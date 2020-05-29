using System;
using System.Collections.Generic;

namespace CRM.CORE
{
    public class UserDetailedApiModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhotoURL { get; set; }
        public virtual string DepartmentName { get; set; }
        public virtual string DepartmentPhone { get; set; }
        public virtual ICollection<PhotosForDetaileApiModel> Photos { get; set; }
    }
}
