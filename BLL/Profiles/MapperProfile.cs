using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;

namespace BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<PositionCreateDTO, Position>().ReverseMap();
            CreateMap<PositionUpdateDTO, Position>();

            CreateMap<Staff, StaffDTO>().ReverseMap();
            CreateMap<StaffCreateDTO, Staff>();
            CreateMap<StaffUpdateDTO, Staff>();
            CreateMap<StaffDeleteDTO, Staff>();
            CreateMap<StaffLoginDTO, Staff>();
            CreateMap<StaffChangePasswordDTO, Staff>();

            CreateMap<Trip, TripDTO>().ReverseMap();
            CreateMap<TripCreateDTO, Trip>();

            CreateMap<Expense, ExpenseDTO>().ReverseMap();
            CreateMap<ExpenseCreateDTO, Expense>();
            CreateMap<ExpenseUpdateDTO, Expense>();

            CreateMap<Approval, ApprovalDTO>().ReverseMap();
            CreateMap<ApprovalSetStatusDTO, Approval>();
        }
        
    }
}
