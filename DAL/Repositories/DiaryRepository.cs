using DAL.IRepositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class DiaryRepository: GenaricRepository<Diary>, IDiaryRepository
    {
        public DiaryRepository(DiaryDbContext context):base(context)
        {

        }
    }
}
