﻿namespace WebApi.Models.Entities
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; }
    }

}
