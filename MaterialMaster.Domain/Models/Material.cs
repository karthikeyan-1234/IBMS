namespace MaterialMaster.Domain.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MaterialCategoryId { get; set; }

        public MaterialCategory? MaterialCategory { get; set; }
    }
}
