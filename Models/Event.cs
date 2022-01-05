﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        public string Name { get; set; }//method
        public string Description { get; set; }
        public string ContactEmail { get; set; }
        public int NumberOfAttendees { get; set; }
        public string Location { get; set; }
        public bool RegistrationIsRequired { get; set; }
        public EventType Type { get; set; }

        public int Id { get; set; }
        
       

        public Event(string name, string description, string contactEmail, int numberOfAttendees, string location, bool registrationIsRequired )//constructor
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
            NumberOfAttendees = numberOfAttendees;
            Location = location;
            RegistrationIsRequired = registrationIsRequired;
            
        }
        public Event()
        {
        }

        public override string ToString()//override
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id == @event.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
