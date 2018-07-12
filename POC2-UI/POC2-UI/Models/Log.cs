using System;

namespace POC2_UI.Models
{
    public class Log
    {
        public Guid Id { get; set; }

        public int LogNumber { get; set; }

        public string Title { get; set; }

        public Guid UnitNumberId { get; set; }

        public Guid AssignedDriverId { get; set; }

    }
}
