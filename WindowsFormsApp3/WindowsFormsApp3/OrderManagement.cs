using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soho_Hotel
{
    internal class OrderManagement
    {
        private string fullName;
        private readonly int orderNum;
        private string phoneNum;
        private readonly Random random;
        public string GetFullName()
        {
            return fullName;
        }
        // Set the full name and perform validation
        public bool SetFullName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!char.IsLetter(name[i]) && name[i] != ' ')
                {
                    return false;
                }
            }
            fullName = name;
            return true;
        }
        // Set the phone number and perform validation
        public bool SetPhoneNum(string phone)
        {
            if (phone.Length>10||phone.Length < 9)
            {
                return false;
            }
            for (int i = 0; i < phone.Length; i++)
            {
                if (phone[i]>'9'|| phone[i]<'0')
                {
                    return false;
                }
            }
            phoneNum = phone;
            return true;
        }
        // Get the phone number
        public string GetPhoneNum() { return phoneNum; }

        // Constructor for OrderManagement class
        public OrderManagement(string fullName, string phone)
        {
            SetFullName(fullName);
            SetPhoneNum(phone);
            random = new Random();
            orderNum = random.Next(1000, 2000);

        }

        // Calculate the total cost based on the number of nights and room type
        public double CalculateTotalCost(int numberOfNights,Rooms roomtype)
        {
            return  (numberOfNights*roomtype.Getprice());
        }

        // Generate the booking details string
        public string bookingDetails()
        {
            string str = "Name under booking:" + fullName + "\r\n";
            str += "Phone number:" + phoneNum + "\r\n";
            str += "Order number:" + orderNum + "\r\n";
            return str;
        }
    }
}
