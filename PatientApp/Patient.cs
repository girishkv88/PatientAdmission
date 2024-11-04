using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp
{
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Slot { get; set; } 
        public DateTime BookingDate { get; set; }

    }
}
