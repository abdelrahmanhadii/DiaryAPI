using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IGenaricRepository<T> where T : BaseModel
    {
        T Create(T model);
        void Update(T model);
        void Delete(int Id);
        IEnumerable<T> GetAll(params string[] Includes);
        IEnumerable<T> Search(Func<T, bool> condition, params string [] Includes);
        T GetByID(int Id);
        void SoftDelete(int Id);
    }
}
