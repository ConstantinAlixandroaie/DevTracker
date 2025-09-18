using System.ComponentModel.DataAnnotations;

namespace DevTracker.Data.Models;

public class Tag
{
    [Key]
    public long Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = "";
    [StringLength(9)]
    public string Colour { get; set; } = "#35FA72";
}
