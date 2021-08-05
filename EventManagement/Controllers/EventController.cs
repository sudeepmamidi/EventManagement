using EventManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Controllers
{
    public class EventController : Controller
    {
        private readonly EventContext _Db;
        public EventController(EventContext Db)
        {
            _Db = Db;
        }
        public IActionResult Index()
        {
            try
            {
                var eventList =_Db.Events.ToList();
                return View(eventList);
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event eve)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                        _Db.Events.Add(eve);
                        await _Db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch ( Exception ex)
            {

                return RedirectToAction("Index");
            }
        }
    }
}
