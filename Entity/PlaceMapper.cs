using DTO;

namespace Entity
{
    public static class PlaceMapper
    {
        public static PlaceEntity ModelToEntity(this Place place)
        {
            return new PlaceEntity
            {
                id = place.id,
                number = place.number

            };
        }
        public static Place EntityToModel(this PlaceEntity place)
        {
            return new Place
            {
                id = place.id,
                number = place.number
            };
        }
    }
}
