using AutoMapper;
using DAL;
using DAL.IRepositories;
using DTOs;
using Models;
using Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DiaryService(IUnitOfWork callRepo, IMapper mapper)
        {
            this._unitOfWork = callRepo;
            this._mapper = mapper;
        }
        public async Task<int> Create(CreateDiaryDTO model)
        {
            var RetVal = _unitOfWork.DiaryRepo.Create(_mapper.Map<Diary>(model));
            if (await _unitOfWork.Save() > 0)
            {
                return RetVal.Id;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<ListDiaryDTO> List(string userId)
        {
            var RetVal = _unitOfWork.DiaryRepo.Search(a=>a.UserId == userId && a.IsDeleted == false).OrderBy(a=>a.DueDate);

            if (RetVal != null)
            {
                return _mapper.Map<IEnumerable<ListDiaryDTO>>(RetVal);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> SoftDelete(int Id)
        {
            _unitOfWork.DiaryRepo.SoftDelete(Id);
            if (await _unitOfWork.Save() > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> Update(UpdateDiaryDTO model)
        {
            _unitOfWork.DiaryRepo.Update(_mapper.Map<Diary>(model));

            if (await _unitOfWork.Save() > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> Completed(int id)
        {
            var entity = _unitOfWork.DiaryRepo.GetByID(id);
            entity.Completed = !entity.Completed;
            _unitOfWork.DiaryRepo.Update(_mapper.Map<Diary>(entity));

            if (await _unitOfWork.Save() > 0)
                return true;
            else
                return false;
        }
    }
}
