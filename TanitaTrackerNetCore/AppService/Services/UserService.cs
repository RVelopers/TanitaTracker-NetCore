using System;
using System.Collections.Generic;
using System.Linq;
using AppService.Dto;
using AppService.Framework;
using Data;
using Domain.Entities;

namespace AppService.Services
{
    public class UserService : IUserService
    {
        private readonly ITanitaTrackerDatabase _tanitaTrackerDatabase;

        public UserService(ITanitaTrackerDatabase tanitaTrackerDatabase )
        {
            _tanitaTrackerDatabase = tanitaTrackerDatabase;
        }
        
        public TaskResult<int> CreateUser(CreateUserDto userDto)
        {
            var result = new TaskResult<int>();

            try
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName =  userDto.LastName,
                    Age =  userDto.Age,
                    Height =  userDto.Height
                };
                _tanitaTrackerDatabase.Add(user);
                _tanitaTrackerDatabase.SaveChanges();
                result.Data = user.Id;
                result.AddMessage("User added succesfully");

            }
            catch (Exception e)
            {
                result.AddErrorMessage(e.Message);
                return result;
            }

            return result;
        }

        public  TaskResult<List<UserIndexDto>> GetMostRecentUsers(int count)
        {
            var result = new TaskResult<List<UserIndexDto>>();

            var data = _tanitaTrackerDatabase.Set<User>().Where(x => x.IsActive)
                .OrderByDescending(x => x.CreatedAt).Select(x => new UserIndexDto
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    Height = x.Height,
                    Age = x.Age
                }).Take(count).ToList();

            result.Data = data;
            
            return result;
        }
        
    }

    public interface IUserService
    {
        TaskResult<int> CreateUser(CreateUserDto userDto);
        TaskResult<List<UserIndexDto>> GetMostRecentUsers(int count);
    }
}