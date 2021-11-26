using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserFormSubmission.Services
{
    public interface IUserService
    {
        bool CheckUserExists(string email);
        string InsertUser(string email, string password);
    }
}