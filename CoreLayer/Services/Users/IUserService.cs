using CoreLayer.DTOs.Users;
using CoreLayer.Utities;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRgesterDto registerDto);
        OperationResult LoginUser(LoginUserDto loginDto);
    }
}
