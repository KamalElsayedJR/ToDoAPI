using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;

namespace ToDo.Core.Interfaces
{
    public interface IToDoRepository : IAsyncDisposable
    {
        Task<IReadOnlyList<ToDoItem>> GetToDoItemsAsync();
        Task<ToDoItem> GetToDoItemByIdAsync(string id);
        Task AddToDoItemAsync(ToDoItem item);
        void Update(ToDoItem item);
        Task Delete(string id);
        Task<int> SaveChangesAsync();
    }
}
