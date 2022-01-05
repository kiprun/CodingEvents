using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        private EventDbContext context;
        public EventsController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        //static private List<Event> Events = new List<Event>();

        [HttpGet]
        public IActionResult Index()
        {
            //Events.Add("Strange Loop");// commemented out because of method NewEvent
            //Events.Add("Grace Hooper");
            //Events.Add("Code with Pride");
            //ViewBag.events = EventData.GetAll();
            //List<Event> events = new List<Event>(EventData.GetAll());
            List<Event> events = context.Events.ToList(); 
            return View(events);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        //Add action controller to handle form submission
        //Everytime a new event is added thru form.  It gets sent to NewEvent method action method which is +
        //which adds into Events list and then is redirected to Index action method and added to ViewBag.events

        [HttpPost] 
        //[Route("/Events/Add")] //Same route as add action method
        public IActionResult Add(AddEventViewModel addEventViewModel)
        //public IActionResult NewEvent(string name, string description)
        {
            //EventData.Add(new Event(name, description));//take in a new event and add to events list
            // Event newEvent = new Event(addEventViewModel.name, addEventViewModel.description);//doing same
            // Event newEvent
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description,
                    ContactEmail = addEventViewModel.ContactEmail,
                    NumberOfAttendees = addEventViewModel.NumberofAttendees,
                    Location = addEventViewModel.Location,
                    RegistrationIsRequired = addEventViewModel.RegistrationIsRequired,
                    Type = addEventViewModel.Type
                };
                // new Event()//steps that Event newEvent are doing
                // newEvent.Name = addEventViewModel.Name;
                // newEvent.Description = addEventViewModel.Description;

                //EventData.Add(newEvent);
                context.Events.Add(newEvent);
                context.SaveChanges();
                return Redirect("/Events");//redirect to route where index responding get request
            }
            return View(addEventViewModel);
            
        }
        public IActionResult Delete()
        {
            //ViewBag.events = EventData.GetAll();
            ViewBag.events = context.Events.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                //EventData.Remove(eventId);
                Event theEvent = context.Events.Find(eventId);
                context.Events.Remove(theEvent);
            }
            context.SaveChanges();

            return Redirect("/Events");
        }
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //Event editingEvent = EventData.GetById(eventId);
            Event editingEvent = context.Events.Find(eventId);
            ViewBag.eventToEdit = editingEvent;
            ViewBag.title = "edit event" + editingEvent.Name + "(id= " + editingEvent.Id + ")";
            return View();
        }
       
        [HttpPost]
        [Route("/events/edit/")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            //Event editingEvent = EventData.GetById(eventId);
            Event editingEvent = context.Events.Find(eventId);
            editingEvent.Name = name;
            editingEvent.Description = description;
            return Redirect("/events/");
        }
        
    }
}
