using System.ComponentModel.DataAnnotations;

namespace HamzilahFoods.Data
{
    public class Menu
    {
        public int ID { get; set; }
        public string ProductName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
