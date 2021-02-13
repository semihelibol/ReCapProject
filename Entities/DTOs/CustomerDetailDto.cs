﻿using Core.DataAcces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int Id { get; set; }
        public int UserId{ get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string CompanyName { get; set; }
    }
}
