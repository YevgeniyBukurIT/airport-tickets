namespace DTO
{
    public class Ticket
    {
        public int id { get; set; }
        public string name { get; set; }
        public Place place { get; set; }
        public decimal price { get; set; }
        public Passanger passanger { get; set; }
        public Flight flight { get; set; }
        public bool isSold { get; set; }
    }
}
