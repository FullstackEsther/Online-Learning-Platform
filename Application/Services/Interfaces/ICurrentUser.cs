using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DomainServices.Interface
{
    public interface ICurrentUser
    {
        string GetLoggedInUserEmail();
        List<string> LoggedInUserRoles();
    }
}