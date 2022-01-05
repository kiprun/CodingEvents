using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter description.")]
        [StringLength(500, ErrorMessage = "Description is too long. Max 500 characters")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Range(0, 10000, ErrorMessage = "Must be a number between 0 -10000.")]
        public int NumberofAttendees { get; set; }

        [Required(ErrorMessage = "Location information required.")]
        public string Location { get; set; }

        public bool IsTrue { get { return true; } }
        [Compare("IsTrue", ErrorMessage = "Registration is required")]
        public bool RegistrationIsRequired { get; set; }

        public EventType Type { get; set; }
        
        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>//<option value="0">Conference<option>
        {
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
            new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString()),
            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString())
        };
        
    }

}
