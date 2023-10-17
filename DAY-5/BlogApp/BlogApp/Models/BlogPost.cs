namespace BlogApp.Models
{
    public class BlogPost
    {
        private string title;
        private string content;
        private string author;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
    }

}
