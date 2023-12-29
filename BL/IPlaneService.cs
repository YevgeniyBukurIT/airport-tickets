using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IPlaneService
    {
        List<Plane> GetAll();
    }
}
