using DTO;
using Entity;
using System.Collections.Generic;

namespace DataLayer
{
    public class PlaneRep : GenericRepository<PlaneEntity, int>, IPlaneRep
    {
        public PlaneRep(MainDbContext context) : base(context)
        {
        }
    }
}
