namespace WebService
{
    using System;
    using System.Collections.Generic;

    public partial class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public string Avatar { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string CreateBy { get; set; }

        public virtual Account Account { get; set; }
    }
}
