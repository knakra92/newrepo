using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;
using Humanizer;

namespace AspNetCoreToDo.Services
{
    public class FakeToDoItemService : IToDoItemService
    {
        public Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new ToDoItem { Title = "Task One", DueAt = DateTimeOffset.Now.AddDays(1) };

            var item2 = new ToDoItem { Title = "Another Task", DueAt = DateTimeOffset.Now.AddDays(2) };

            return Task.FromResult(new[] { item1, item2 });
        }
    }
}