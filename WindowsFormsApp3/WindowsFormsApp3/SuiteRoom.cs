using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_Hotel
{
    internal class SuiteRoom : Rooms
    {
        private readonly string roomType = "Suite Room";

        // Constructor for the SuiteRoom class
        public SuiteRoom() : base(60, 2, 1999.99)
        {
            
        }

        // Get the room type
        public string Gettype() { return roomType; }

        // Override the ToString() method to provide a string representation of the suite room
        public override string ToString()
        {
            return "Room type: " + roomType + "\n\r" + base.ToString() + "In the well-equipped kitchenette, guests will find a refrigerator, a dishwasher, a tea and coffee maker and a toaster.\n\r The spacious double room offers air conditioning, soundproof walls, a terrace with garden views as well as a private bathroom boasting a bath.\n\r The unit has 1 bed.";
        }
    }
}
