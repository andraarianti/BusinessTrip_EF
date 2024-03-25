using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Data.Interfaces;

namespace BLL
{
    public class ApprovalBLL : IApprovalBLL
    {
        private readonly IApprovalData _approvalData;
        private readonly IMapper _mapper;
        public ApprovalBLL(IApprovalData approvalData, IMapper mapper)
        {
            _approvalData = approvalData;
            _mapper = mapper;
        }
        public async Task<bool> SetApproval(ApprovalSetStatusDTO entity)
        {
            var approval = _mapper.Map<Approval>(entity);
            var result = await _approvalData.SetApproval(approval);
            return result;
        }

        public async Task<bool> SetRejection(ApprovalSetStatusDTO entity)
        {
            var approval = _mapper.Map<Approval>(entity);
            var result = await _approvalData.SetRejection(approval);
            return result;
        }
    }
}
