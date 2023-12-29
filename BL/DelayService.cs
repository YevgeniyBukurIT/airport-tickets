using DataLayer;
using DTO;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class DelayService : IDealyService
    { 
	    private readonly IUnitOfWork _unitOfWork;
        public DelayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<DelayReason> GetAll() => _unitOfWork.reasons
	        .GetAll()
	        .Select(r => r.EntityToModel())
	        .ToList();
    }
}
