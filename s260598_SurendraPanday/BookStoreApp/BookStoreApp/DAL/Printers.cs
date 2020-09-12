using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.DAL
{
    public class Printer
    {
      //(ID, Name, Brand, Model)

        public int Id { get; set; }

        public string Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        public string Brand { get; set; }

        public string Model { get; set; }
    }
}
