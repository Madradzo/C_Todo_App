using C_TODO.DB;
using C_TODO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_TODO.Controllers
{
    public class ToDoController : Controller
    {

        private readonly ToDoContext context;

        public ToDoController(ToDoContext context) 
        {
            this.context = context;
        }

        //GET list view
        public async Task<ActionResult> Index()
        {
            IQueryable<ToDoList> items = from i in context.ToDoList orderby i.Id select i;

            List<ToDoList> todoList = await items.ToListAsync();

            return View(todoList);
        }

        // GET create view
        // Returnina todo itemo sukurimo langa
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDoList item)
        {
            if (ModelState.IsValid) 
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET edit view
        public async Task<ActionResult> Edit(int id)
        {

            ToDoList item = await context.ToDoList.FindAsync(id);
            if (item == null) 
            {
                return NotFound();
            }

            return View(item);
        }

        //POST request, talpinti paeditinta itema
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        //GET delete item
        public async Task<ActionResult> Delete(int id)
        {

            ToDoList item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item doesn't exist!";
            }
            else 
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
