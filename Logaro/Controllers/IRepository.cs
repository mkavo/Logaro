using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logaro.App_Data;

namespace Logaro.Controllers
{
    public interface IRepository<T>
    {
        void Index(T objectToIndex, IUnitOfWork uow);

        void Delete(T objectToDelete, IUnitOfWork uow);

        void Update(T objectToUpdate, IUnitOfWork uow);

        void Create(T objectToCreate, IUnitOfWork uow);

        T Read(int id);

        List<T> ReadAll();

    }
}



