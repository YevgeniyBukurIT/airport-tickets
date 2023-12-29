using DataLayer;
using DTO;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class PlaneService : IPlaneService
    {
	    private readonly IUnitOfWork _unitOfWork;
	    public PlaneService(IUnitOfWork unitOfWork)
	    {
		    _unitOfWork = unitOfWork;
	    }
	    public List<Plane> GetAll() =>
		    _unitOfWork.planes
			    .GetAll()
			    .Select(plane => plane.EntityToModel())
			    .ToList();
    }
}
