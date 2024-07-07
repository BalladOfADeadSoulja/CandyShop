using CandyShop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandyShop.Models
{
    [Table("category")]
    public class Category
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("name")]
        [Required(ErrorMessage = "Название должно быть указано")]
        [MaxLength(30, ErrorMessage = "Название должно быть не более 30 и не менее 1 символа")]
        public string Name { get; set; }
        public ICollection<Candy> Candys { get; set; }
    }
}
