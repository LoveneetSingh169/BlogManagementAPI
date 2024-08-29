namespace BlogManagement.Core.Entity
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Text { get; set; }
    }
}
