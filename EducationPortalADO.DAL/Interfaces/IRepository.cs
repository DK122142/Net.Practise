﻿using System;
using System.Collections.Generic;

namespace EducationPortalADO.DAL.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        IEnumerable<T> Find(Func<T, Boolean> predicate);

        T Create(T item);

        T Update(T item);

        void Delete(int id);
    }
}
