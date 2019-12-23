using DAL.IRepositories;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        IDiaryRepository DiaryRepo { get; }
        Task<int> Save();
    }
}
