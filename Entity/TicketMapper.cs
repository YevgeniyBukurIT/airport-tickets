using DTO;

namespace Entity
{
    public static class TicketMapper
    {
        public static TicketEntity ModelToEntity(this Ticket t)
        {
            string name = "";
            if (t.name != null)
            {
                name = t.name;
            }
           
            if (t.passanger == null) {
                return new TicketEntity
                {
                    id = t.id,
                    name = name,
                    placeId = t.place.id,
                    price = t.price,
                    passangerId = null,
                    isSold = t.isSold,
                };
            }
            return new TicketEntity
            {
                id = t.id,
                name = name,
                placeId = t.place.id,
                price = t.price,
                passangerId = t.passanger.id,
                isSold = t.isSold,
            };


        }
        public static Ticket EntityToModel(this TicketEntity t)
        {
            string name = "";
            if (t.name != null)
            {
                name = t.name;
            }

            if (t.passanger == null)
            {
                return new Ticket
                {
                    id = t.id,
                    name = name,
                    place = t.place.EntityToModel(),
                    price = t.price,
                    passanger = null,
                    isSold = t.isSold,
                };
            }
            return new Ticket
            {
                id = t.id,
                name = name,
                place = t.place.EntityToModel(),
                price = t.price,
                passanger = t.passanger.EntityToModel(),
                isSold = t.isSold,
            };
        }
    }
}
