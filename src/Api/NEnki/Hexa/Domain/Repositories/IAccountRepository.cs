﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

        Task<Account> GetByIdAsync(Guid accountId, CancellationToken cancellationToken = default);

        void Insert(Account account);

        void Remove(Account account);
    }
}