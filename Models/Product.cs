using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureLabNew.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Значение должно быть больше 1")]
        public double Price { get; set; }

        public string Image { get; set; }

        // Явное добавление представления для внешнего ключа
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        // Добавление внешнего ключа - связь с другой таблицей
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
