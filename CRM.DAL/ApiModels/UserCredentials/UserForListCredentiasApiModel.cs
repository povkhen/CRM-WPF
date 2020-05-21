﻿using System;

namespace CRM.DAL.ApiModels
{

    /// <summary>
    /// The credentials for an API client to get list view of user
    /// </summary>
    class UserForListCredentiasApiModel
    {
        #region Public Properties
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
        public string DepartmentName { get; set; }
        public string PhotoURL { get; set; }

        #endregion
    }
}
