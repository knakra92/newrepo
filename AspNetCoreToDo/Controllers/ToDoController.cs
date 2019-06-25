using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreToDo.Services;
using AspNetCoreToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCoreToDo.Controllers
{
    
    public class ToDoController : Controller
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoController(IToDoItemService todoItemService)
        {
            _toDoItemService = todoItemService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _toDoItemService.GetIncompleteItemsAsync();

            StringBuilder str = null;

            str.Append("");

            return View(new ToDoViewModel { Items = items });
        }

        
        public async Task<IActionResult> AddItem(ToDoItem toDoItem)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _toDoItemService.AddItemAsync(toDoItem);

            if (!successful)
            {
                return BadRequest("Cound not bind to model");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkDone(Guid id)
        {
            //Func<IActionResult> redirect = () => RedirectToAction("Index");

            IActionResult redir()
            {
                return RedirectToAction("Index");
            }

            if(id == Guid.Empty)
            {
                return redir();
            }

            if(!await _toDoItemService.MarkDoneAsync(id))
            {
                return BadRequest("Bad Request, cou not mark it done.");
            }

            return redir();
        }
    }
}