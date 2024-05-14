using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {phoneNumber}";
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(c => char.IsDigit(c));
        }
    }
}
