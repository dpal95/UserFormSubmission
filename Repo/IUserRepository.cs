using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserFormSubmission.Repo
{
    public interface IUserRepository
    {
        bool checkUserExists(string email);
    }
}