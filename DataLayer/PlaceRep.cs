using DTO;
using Entity;

namespace DataLayer
{
    public class PlaceRep : GenericRepository<PlaceEntity, int>, IPlaceRep
    {
        public PlaceRep(MainDbContext context) : base(context)
        {
        }
    }
}
