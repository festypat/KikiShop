using AutoMapper;
using KikiShop.ApplicationCore.Merchants.Command;
using KikiShop.Helper.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.AutoMapperSettings
{
  
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateMerchantRequest, RegisterMerchantCommand>()
            .ConstructUsing(c => new RegisterMerchantCommand(c.Email, c.Name, c.Password, c.PasswordConfirm));
        }
    }
}
