using DTO;
using System.Collections.Generic;

namespace Entity
{
    public static class PlaneMapper
    {
        public static PlaneEntity ModelToEntity(this Plane plane)
        {
            List<PlaceEntity> places = new List<PlaceEntity>();
            foreach (Place s in plane.places)
            {
                places.Add(s.ModelToEntity());
            }
            return new PlaneEntity
            {
                id = plane.id,
                name = plane.name,
                places = places
            };
        }
        public static Plane EntityToModel(this PlaneEntity plane)
        {
            List<Place> places = new List<Place>();
            foreach (PlaceEntity s in plane.places)
            {
                places.Add(s.EntityToModel());
            }
            return new Plane
            {
                id = plane.id,
                name = plane.name,
                places = places
            };
        }
    }
}
