using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }


        public string Browse(string url)
        {
            if (!IsValidUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(c => char.IsDigit(c));
        }
        private bool IsValidUrl(string url)
        {
            return url.All(c => !char.IsDigit(c));
        }

    }
}
