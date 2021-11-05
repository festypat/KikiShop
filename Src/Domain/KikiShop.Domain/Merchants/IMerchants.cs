﻿using KikiShop.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.Domain.Merchants
{

    public interface IMerchants : IRepository<Merchant>
    {
        Task Add(Merchant customer, CancellationToken cancellationToken = default);
        Task<Merchant> GetById(MerchantId id, CancellationToken cancellationToken = default);
        Task<Merchant> GetByEmail(string email, CancellationToken cancellationToken = default);
    }
}
