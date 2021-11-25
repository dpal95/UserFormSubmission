using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserFormSubmission.Repo;

namespace UserFormSubmission.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CheckUserExists(string email)
        {
            return _userRepository.checkUserExists(email);
        }

        public bool InsertUser(string email, string password)
        {
            return _userRepository.InsertUser(email,password);
        }
    }
}