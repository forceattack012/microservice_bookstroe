namespace Book.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } = 0;
        public int Qty { get; set; } = 0;
        public int Pages { get; set; } = 0;
        public string Language { get; set; }
        public DateTime? Published { get; set; }
        public List<string> Authors { get; set; }
        public string Image { get; set; }
        public string ISBN { get; set; }
        public string Descripttion { get; set; }
        public Double Rating { get; set; }
    }
}
