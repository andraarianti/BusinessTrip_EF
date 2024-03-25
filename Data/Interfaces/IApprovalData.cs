using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;

namespace Data.Interfaces
{
    public interface IApprovalData
    {
        Task<bool> SetApproval(Approval approval);
        Task<bool> SetRejection(Approval approval);
    }
}
