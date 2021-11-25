using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserFormSubmission.Repo
{
    public interface IUserRepository
    {
        bool CheckUserExists(string email);
        bool InsertUser(string email, string password);
        bool RemoveUser(string email);
    }
}