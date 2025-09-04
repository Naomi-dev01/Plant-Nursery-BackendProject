using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantNursery.DTO.UserDto
{
    public class UserCreateDto
    {
        public int Id { get; set; } // נוצר אוטומטית ב-DB
        public string Username { get; set; }
        public string PasswordHash { get; set; } // לא hash – נקבל plain ונצפין ב-Service
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
       
    }
}
