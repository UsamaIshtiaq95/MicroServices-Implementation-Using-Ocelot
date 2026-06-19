
using System.ComponentModel.DataAnnotations;

namespace UserDomain.Entities;

public class ApiKeys
{
    [Key]
    public int ApiKeyId { get; set; }

    [Required, MaxLength(100)]
    public string ServiceName { get; set; }

    [Required, MaxLength(500)]
    public string Key { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
