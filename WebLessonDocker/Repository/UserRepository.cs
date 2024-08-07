﻿using System.Text;
using WebLessonDocker.Abstraction;
using WebLessonDocker.DbCon;
using WebLessonDocker.Dto;
using WebLessonDocker.Models;
using System.Security.Cryptography;

namespace WebLessonDocker.Repository
{
    public class UserRepository : IUserRepository
    {
        UserContext context;
        public UserRepository(UserContext userContext)
        {
            context = userContext;
        }
        public int AddUser(UserDto user)
        {
            if (context.Users.Any(x => x.Name == user.Name))
                throw new Exception("User is already exist!");
            if (user.Role == RoleIdDto.Admin)
                if (context.Users.Any(x => x.RoleId == RoleId.Admin))
                    throw new Exception("Admin is already exist!");

            var entity = new User { Name = user.Name, RoleId = (RoleId)user.Role };
            entity.Salt = new byte[16];
            new Random().NextBytes(entity.Salt);
            var data = Encoding.UTF8.GetBytes(user.Password).Concat(entity.Salt).ToArray();
            entity.Password = new SHA512Managed().ComputeHash(data);
            context.Users.Add(entity);
            context.SaveChanges();

            return entity.Id;
        }

        public RoleIdDto CheckUser(LoginDto login)
        {
            var user = context.Users.FirstOrDefault(x => x.Name == login.Name);
            if (user == null) throw new Exception("No user like this!");
            var data = Encoding.UTF8.GetBytes(login.Password).Concat(user.Salt).ToArray();
            var hash = new SHA512Managed().ComputeHash(data);

            if (user.Password.SequenceEqual(hash))
                return (RoleIdDto)user.RoleId;
            throw new Exception("Wrong password!");
        }
    }
}
