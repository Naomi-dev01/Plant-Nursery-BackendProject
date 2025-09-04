namespace PlantNursery.API.Models
{
    public class UserCreateRequest
    {
       // public int Id { get; set; }

        public string Username { get; set; } = null!;

      //  public string PasswordHash { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}
