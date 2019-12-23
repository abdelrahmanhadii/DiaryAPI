using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.IRepositories;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDiaryRepository diaryRepo;
        private readonly DiaryDbContext _context;
        public UnitOfWork(DiaryDbContext context)
        {
            this._context = context;
        }
        public IDiaryRepository DiaryRepo
        {
            get
            {
                if (diaryRepo == null)
                {
                    diaryRepo = new DiaryRepository(_context);
                }
                return diaryRepo;
            }
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
