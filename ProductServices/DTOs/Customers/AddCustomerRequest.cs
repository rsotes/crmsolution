using System.Collections.Generic;

namespace ProductServices.DTOs.Customers
{
    public class AddCustomerRequest
    {
        public string Name { get; set; }

        public List<AddressDto> Addresses { get; set; }

        public PhoneNumberDto Phone { get; set; }
    }
}
