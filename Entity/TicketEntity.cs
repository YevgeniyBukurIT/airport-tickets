namespace Entity
{
    public class TicketEntity : BaseEntity<int>
    {
        public string name { get; set; }
        public virtual PlaceEntity place { get; set; }
        public int placeId { get; set; }
        public decimal price { get; set; }
        public virtual PassangerEntity? passanger { get; set; }
        public int? passangerId { get; set; }
        public bool isSold { get; set; }
    }
}
