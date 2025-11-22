using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;
using ToDo.Repository.Data;

namespace ToDo.Repository.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _dbContext;

        public ToDoRepository(ToDoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddToDoItemAsync(ToDoItem item)
        => await _dbContext.AddAsync(item);

        public async Task Delete(string id)
        {
            var item = await GetToDoItemByIdAsync(id);
            _dbContext.Remove(item);
        }
        public async ValueTask DisposeAsync()
        => await _dbContext.DisposeAsync();

        public async Task<ToDoItem> GetToDoItemByIdAsync(string id)
        => await _dbContext.FindAsync<ToDoItem>(id);

        public async Task<IReadOnlyList<ToDoItem>> GetToDoItemsAsync()
        => await _dbContext.ToDoItems.ToListAsync();

        public async Task<int> SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
        
        public void Update(ToDoItem item)
        =>  _dbContext.Update(item);
    }
}
