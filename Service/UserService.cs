﻿using Service_User.Data;
using Service_User.Model;
using Service_User.Service.Interface;

namespace Service_User.Service
{
    public class UserService : IUserService
    {

        // Pour le test

        private readonly UserDbContext _dbContext;
        public UserService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User AddUser(User product)
        {
            var result = _dbContext.Users.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteUser(int Id)
        {
            var filteredData = _dbContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(x => x.UserId == id).FirstOrDefault();
        }
        public IEnumerable<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }
        public User UpdateUser(User product)
        {
            var result = _dbContext.Users.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
