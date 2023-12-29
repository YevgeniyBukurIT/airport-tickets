using DTO;
using Entity;
using System.Collections.Generic;

namespace DataLayer
{
    public class AirportRep : GenericRepository<AirportEntity, int>, IAirportRep
    {
        public AirportRep(MainDbContext context) : base(context)
        {
        }
    }
}
