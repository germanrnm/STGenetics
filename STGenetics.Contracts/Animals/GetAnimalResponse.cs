namespace STGenetics.Contracts.Animals;

public class GetAnimalResponse {
    public int Id { get; set; }
    public bool Selected { get; set; } = false;
    public string Name { get; set; } = null!;
    public string Breed { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Sex { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal FinalPrice { get; set; }
    public string Status { get; set; } = null!;
}
