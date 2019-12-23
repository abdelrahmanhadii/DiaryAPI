using DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceContracts
{
    public interface IDiaryService
    {
        Task<int> Create(CreateDiaryDTO model);

        IEnumerable<ListDiaryDTO> List(string userId);

        Task<bool> SoftDelete(int Id);

        Task<bool> Update(UpdateDiaryDTO model);

        Task<bool> Completed(int id);
    }
}
