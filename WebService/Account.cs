//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
        public string Fullname { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
    }
}
