using CsvHelper.Configuration.Attributes;

namespace Book.Infrastructure.Data
{
    public class BookCsv
    {
        [Index(0)]
        public string book_id { get; set; }
        [Index(4)]
        public Int32 book_count { get; set; }
        [Index(6)]
        public string isbn { get; set; }
        [Index(7)]
        public string authors { get; set; }

        [Index(10)]
        public string title { get; set; }

        [Index(11)]
        public string language_code { get; set; }

        [Index(12)]
        public Double ratings_count { get; set; }

        [Index(20)]
        public string imageUrl { get; set; }   

    }
}
