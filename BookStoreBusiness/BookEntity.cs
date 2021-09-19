namespace BookStoreBusiness
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public int Price { get; set; }
        public PriceCategory BookCategory { get; set; }
    }

    public enum PriceCategory
    {
        Expensive,
        Cheap,
        Normal
    }
}
