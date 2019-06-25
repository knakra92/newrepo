using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetCoreToDo.Data;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            return await _context.Items.Where(x => x.IsDone == false).ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(ToDoItem toDoItem)
        {
            toDoItem.Id = Guid.NewGuid();
            toDoItem.IsDone = false;
            toDoItem.DueAt = DateTimeOffset.Now.AddDays(2);

            _context.Items.Add(toDoItem);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (item == null) return false;

            item.IsDone = true;

            return await _context.SaveChangesAsync() == 1;
        }
    }
}