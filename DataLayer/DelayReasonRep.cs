using Entity;

namespace DataLayer
{
    public class DelayReasonRep : GenericRepository<DelayReasonEntity, int>, IDelayReasonRep
    {
        public DelayReasonRep(MainDbContext context) : base(context)
        {
        }
    }
}
