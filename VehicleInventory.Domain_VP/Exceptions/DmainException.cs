using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain_VP.Exceptions
{
    // DomainException is used to represent violations of business rules
    // or invalid state transitions within the Domain layer.
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}