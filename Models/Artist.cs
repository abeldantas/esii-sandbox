using System.ComponentModel.DataAnnotations;

namespace Sandbox.Models;

public class Artist
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Country { get; set; }
}