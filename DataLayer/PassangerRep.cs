using Entity;

namespace DataLayer
{
    public class PassangerRep : GenericRepository<PassangerEntity, int>, IPassangerRep
    {
        public PassangerRep(MainDbContext context) : base(context)
        {
        }
        
    }
}
