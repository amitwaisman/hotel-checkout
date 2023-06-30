using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_Hotel
{
    internal abstract class Rooms 
    {
        protected int size;
        protected int numOfPeople;
        protected double price;

        // Constructor for the Rooms class

        public Rooms (int size, int numOfPeople, double price)
        {
            this.size = size;
            this.numOfPeople = numOfPeople;    
            this.price = price;
        }

        // Override the ToString() method to provide a string representation of the room
        public override string ToString()
        {
            string str = "";
            str += "Room size " + size + "\r\n";
            str += "Max number of people in room : " + numOfPeople + "\r\n";
            str += "Price Per Night: " + price + "\r\n";
            return str;
        }
        public double Getprice() { return price; }
        public int GetSize() { return size; }
        public int GetNumberOfPeople() { return numOfPeople; }
    }
}
