using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IApprovalBLL
    {
        Task<bool> SetApproval(ApprovalSetStatusDTO entity);
        Task<bool> SetRejection(ApprovalSetStatusDTO entity);
    }
}
