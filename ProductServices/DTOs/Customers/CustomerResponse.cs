﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.DTOs.Customers
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AddressDto Address { get; set; }

        public PhoneNumberDto PhoneNumber { get; set; }
    }
}
