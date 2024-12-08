﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository : IBaseRepositoryAsync<User>
    {
        int CheckUser(string username, string password);
    }
}
