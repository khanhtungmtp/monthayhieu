namespace WebService
{
    using System;
    using System.Collections.Generic;

    public partial class Account
    {
        public Account()
        {
            this.Articles = new HashSet<Article>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Status { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}