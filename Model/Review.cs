namespace RVezyTestApp.Model
{
    public class Review
    {
        public int id { get; set; }

        public ListingsModel listings { get; set; }
        public DateOnly date { get; set; }
        public  String name { get; set; }
        public string comments { get; set; }        
    }
}
