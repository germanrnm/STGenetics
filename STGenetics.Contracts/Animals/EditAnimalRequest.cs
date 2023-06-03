using System.ComponentModel.DataAnnotations;

namespace STGenetics.Contracts.Animals;

public class EditAnimalRequest {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Breed { get; set; } = null!;
    [Required]
    public DateTime? BirthDate { get; set; }
    [Required]
    public string Sex { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Status { get; set; }
}