using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AP.Entities.DataModels;

public partial class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    //public long? CartId { get; set; }

    public string Gender { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? MobileNo { get; set; }

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    [NotMapped]
    public string? Token { get; set; }

    [NotMapped]
    public string? Otp { get; set; }
}
