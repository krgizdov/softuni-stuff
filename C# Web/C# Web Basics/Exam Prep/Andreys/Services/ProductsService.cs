namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }
        public int Add(ProductAddInputModel productAddInputModel)
        {
            var categoryAsEnum = Enum.Parse<Category>(productAddInputModel.Category);
            var genderAsEnum = Enum.Parse<Gender>(productAddInputModel.Gender);

            var product = new Product()
            {
                Name = productAddInputModel.Name,
                Description = productAddInputModel.Description,
                ImageUrl = productAddInputModel.ImageUrl,
                Price = productAddInputModel.Price,
                Category = categoryAsEnum,
                Gender = genderAsEnum,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public IEnumerable<Product> GetAll()
            => this.db.Products.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            })
            .ToArray();

        public Product GetById(int id)
            => this.db.Products.FirstOrDefault(x => x.Id == id);

        public void DeleteById(int id)
        {
            this.db.Products.Remove(this.GetById(id));
            db.SaveChanges();
        }
    }
}
