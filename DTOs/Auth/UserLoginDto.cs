﻿using System.ComponentModel.DataAnnotations;

namespace SmileShop.API.DTOs
{
    public class UserLoginDto
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}