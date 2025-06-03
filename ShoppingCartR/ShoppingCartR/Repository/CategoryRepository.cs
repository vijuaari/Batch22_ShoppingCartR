﻿using ShoppingCartR.Models;

namespace ShoppingCartR.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public ApplicationDbContext _db;
         public CategoryRepository (ApplicationDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update (Category obj)
        {
            _db.Category.Update(obj);
        }
    }
}
