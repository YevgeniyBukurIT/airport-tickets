using Entity;

namespace DataLayer
{
    public class TicketRep : GenericRepository<TicketEntity, int>, ITicketRep
    {
        public TicketRep(MainDbContext context) : base(context)
        {
        }
        
    }
}
