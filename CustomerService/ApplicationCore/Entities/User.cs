using System.ComponentModel.DataAnnotations;
using ApplicationCore.Model;

namespace ApplicationCore.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string Role { get; set; }
}