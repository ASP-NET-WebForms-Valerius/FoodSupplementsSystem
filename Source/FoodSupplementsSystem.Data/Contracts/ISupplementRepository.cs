﻿using System.Collections.Generic;
using FoodSupplementsSystem.Data.Models;

namespace FoodSupplementsSystem.Data.Repositories.Contracts
{
    public interface ISupplementRepository
    {
        IEnumerable<Supplement> GetFilteredByCategory(string categoryName);

        IEnumerable<Supplement> GetFilteredByTopic(string topicName);

        IEnumerable<Supplement> GetFilteredByBrand(string brandName);
    }
}