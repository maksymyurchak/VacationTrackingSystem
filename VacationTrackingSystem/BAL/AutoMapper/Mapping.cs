using AutoMapper;
using Models.Entities;
using Models.Entities.Enums;
using Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.AutoMapper
{
    class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<VacationRequestDTO, VacationRequest>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<VacationRequest, VacationRequestDTO>().
                ForMember(vd => vd.Status, vb => vb.MapFrom(f => Enum.GetName(typeof(Status), f.Status))).
                ForMember(vd => vd.VacationType, vb => vb.MapFrom(f => Enum.GetName(typeof(VacationType), f.VacationType)));


        }
    }
}
