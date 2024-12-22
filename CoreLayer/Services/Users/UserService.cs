using CoreLayer.DTOs.Users;
using CoreLayer.Utities;
using DataLayer.Context;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }

        public OperationResult RegisterUser(UserRgesterDto registerDto)
        {
            var isUserNameExist = _context.Users.Any(u => u.UserName == registerDto.UserName);
            if (isUserNameExist)
               return OperationResult.Error("نام کاربری تکراری است");

            var passwordHash = registerDto.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                FullName = registerDto.Fullname,
                IsDelete = false,
                UserName = registerDto.UserName,
                Role = UserRole.User,
                CreationDate = DateTime.Now,
                Password = passwordHash
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }
        public OperationResult LoginUser(LoginUserDto loginDto)
        {
            var passwordHashed=loginDto.Password.EncodeToMd5();
            var isUserExist= _context.Users.Any(u => u.UserName==loginDto.UserName && u.Password==passwordHashed);
            if(isUserExist==false)
                return OperationResult.NotFound();

            return OperationResult.Success();
            

            
        }
    }
}
