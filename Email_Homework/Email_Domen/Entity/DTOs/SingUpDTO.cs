﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Domen.Entity.DTOs
{
    public class SingUpDTO
    {
        [EmailAddress]
        public string Email {  get; set; }
        public string Password {  get; set; }
        public string confirmationcode {  get; set; }
    }
}
