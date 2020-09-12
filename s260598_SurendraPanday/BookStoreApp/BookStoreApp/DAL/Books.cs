using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.DAL
{
    public class Book
    {
        //Define id and name
        [Range(1, 1000)]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public double Price { get; set; }

    }
}
