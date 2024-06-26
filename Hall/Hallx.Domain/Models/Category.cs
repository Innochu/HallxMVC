﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hallx.Domain.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
