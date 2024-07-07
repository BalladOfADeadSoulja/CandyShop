using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CandyShop.Models;

namespace CandyShop.Models
{
    [Table("candy")]
    public class Candy
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("name")]
        [Required(ErrorMessage = "Название должно быть указано")]
        [MaxLength(30, ErrorMessage = "Название должно быть не более 30 и не менее 1 символа")]
        public string Name { get; set; }

        [Column("price")]
        [Required(ErrorMessage = "Цена должна быть указана")]
        [Range(1, int.MaxValue, ErrorMessage = "Цена не должна быть отрицательной")]
        public int Price { get; set; }

        [Column("size")]
        [Required(ErrorMessage = "Размер должен быть указан")]
        [Range(1, int.MaxValue, ErrorMessage = "Размер должен быть в диапазоне от 18 до 50")]
        public int Size { get; set; }

        /*[Column("color")]
        [Required(ErrorMessage = "Цвет должен быть указан")]
        [MaxLength(30, ErrorMessage = "Название цвета не должно превышать 30 и не быть менее 1 символа")]
        public string Color { get; set; }*/

        [Column("quantity")]
        [Required(ErrorMessage = "Количество товара должно быть указано")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество товара не должно быть отрицательным")]
        public int Quantity { get; set; }

        /*[Column("brandid")]
        [Required]
        public long BrandId { get; set; }*/

        [Column("description")]
        [Required(ErrorMessage = "Опмисание товара должно быть указано")]
        [MaxLength(30, ErrorMessage = "Описание не может быть незаполенным")]
        public string Description { get; set; }

        [Column("categoryid")]
        [Required]
        public long CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
