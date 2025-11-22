using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.DTOs;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces
{
    public interface IToDoServices
    {
        Task<IReadOnlyList<ToDodto?>> GetAllAsync();
        Task<ToDodto?> GetByIdAsync(string id);
        Task<ToDodto?> CreateAsync(CreateToDodto item);
        Task<ToDodto?> UpdateAsync(string id, UpdateToDodto item);
        Task<bool> ChangeStatusAsync(string id,bool IsCompleted);
        Task<bool> DeleteAsync(string id);
    }
}
