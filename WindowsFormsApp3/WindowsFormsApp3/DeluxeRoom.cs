using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_Hotel
{
    internal class DeluxeRoom : Rooms
    {
        private readonly string roomType = "Deluxe Room";


        // Constructor for the DeluxeRoom class
        public DeluxeRoom() : base(35, 2, 1299.99)
        {
            
        }
        // Get the room type
        public string Gettype() { return roomType; }

        // Override the ToString() method to provide a string representation of the deluxe room
        public override string ToString()
        {
            return "Room type: " + roomType + "\n\r" + base.ToString() + "The spacious double room provides air conditioning, soundproof walls, as well as a private bathroom featuring a bath and a shower.\n\r The double room is furnished with a desk and a seating area and features a mini-bar, a tea and coffee maker and garden views.\n\r The unit offers 1 bed.\n\r";
        }
    }
}
