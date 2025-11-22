using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.DTOs;
using ToDo.Core.Entities;
using ToDo.Core.Interfaces;

namespace ToDo.Services
{
    public class ToDoService : IToDoServices
    {
        private readonly IToDoRepository _toDoRepo;
        private readonly IMapper _mapper;
        public ToDoService(IToDoRepository toDoRepo,IMapper mapper)
        {
            _toDoRepo = toDoRepo;
            _mapper = mapper;
        }
        public async Task<bool> ChangeStatusAsync(string id, bool IsCompleted)
        {
            var Task = await _toDoRepo.GetToDoItemByIdAsync(id);
            if (Task == null) return false;
            Task.IsCompleted = IsCompleted;
            Task.UpdatedAt = DateTimeOffset.Now;
            _toDoRepo.Update(Task);
            return await _toDoRepo.SaveChangesAsync() > 0;
        }
        public async Task<ToDodto?> CreateAsync(CreateToDodto item)
        {
            var Task = _mapper.Map<CreateToDodto, ToDoItem>(item);
            Task.CreatedAt = DateTimeOffset.Now;
            await _toDoRepo.AddToDoItemAsync(Task);
            if (await _toDoRepo.SaveChangesAsync() <= 0) return null;
            return _mapper.Map<ToDoItem, ToDodto>(Task);
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var Task = await _toDoRepo.GetToDoItemByIdAsync(id);
            if (Task == null) return false;
            _toDoRepo.Delete(id);
            return await _toDoRepo.SaveChangesAsync() > 0 ;
        }
        public async Task<IReadOnlyList<ToDodto?>> GetAllAsync()
        {
            var Tasks = await _toDoRepo.GetToDoItemsAsync();
            return _mapper.Map<IReadOnlyList<ToDoItem>, IReadOnlyList<ToDodto>>(Tasks);
        }
        public async Task<ToDodto?> GetByIdAsync(string id)
        {
            var Task = await _toDoRepo.GetToDoItemByIdAsync(id);
            if (Task == null) return null;
            return _mapper.Map<ToDoItem, ToDodto>(Task);
        }
        public async Task<ToDodto?> UpdateAsync(string id, UpdateToDodto item)
        {
            var ExTask = await _toDoRepo.GetToDoItemByIdAsync(id);
            if (ExTask == null) return null;
            _mapper.Map<UpdateToDodto, ToDoItem>(item, ExTask);
            ExTask.UpdatedAt = DateTimeOffset.Now;
            _toDoRepo.Update(ExTask);
            if (await _toDoRepo.SaveChangesAsync() <= 0) return null;
            return _mapper.Map<ToDoItem, ToDodto>(ExTask);
        }
    }
}
