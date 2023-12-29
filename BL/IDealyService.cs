using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IDealyService
    {
        List<DelayReason> GetAll();
    }
}
