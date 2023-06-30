using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_Hotel
{
    internal class StandardRoom : Rooms
    {
        private readonly string roomType = "Standard Room";

        // Constructor for the StandardRoom class
        public StandardRoom() : base( 20, 2, 999.99)
        {
            // The base constructor of the Rooms class is called with specific values for size, numOfPeople, and price.
            // In this case, the size is set to 20, maximum occupancy is set to 2, and the price per night is set to 999.99.
        }

        // Get the room type
        public string Gettype() { return roomType; }

        // Override the ToString() method to provide a string representation of the standard room
        public override string ToString()
        {
            return "Room type: " + roomType + "\n\r" + base.ToString() + "Providing free toiletries and bathrobes, this double room includes a private bathroom with a shower, a hairdryer and slippers.\n\r The double room provides air conditioning, soundproof walls and a mini-bar and wine/champagne is provided for guests.\n\r The unit offers 1 bed.\n\r";
        }
    }
}
