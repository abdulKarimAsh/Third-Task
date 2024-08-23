namespace Web.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string PublicationYear { get; set; }

        public int SubCategoryId { get; set; }

        public int AuthorId { get; set; }
    }
}
