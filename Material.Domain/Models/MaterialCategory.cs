namespace Material.Domain.Models
{
    public class MaterialCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Material>? Materials;
    }
}
