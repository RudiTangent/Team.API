using System;

namespace Teams.API.Model
{
    public class Projects
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }
    }
}