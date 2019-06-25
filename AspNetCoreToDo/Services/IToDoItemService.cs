using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(ToDoItem toDoItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}