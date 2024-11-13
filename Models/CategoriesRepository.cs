namespace WebApp.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>{
                new Category{CategoryId=1, Name="Beverage", Description="Beverage"},
                new Category{CategoryId=2, Name="Bakery", Description="Bakery"},
                new Category{CategoryId=3, Name="Meat", Description="Meat"}
            };

        public static void AddCategory(Category category)
        {
            if (_categories != null && _categories?.Count > 0)
            {
                var maxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;
            }
            _categories ??= new List<Category>(); //if(_categories==null) _categories=new List<Category>();
            _categories.Add(category);
        }
        public static List<Category> GetCategories()
        {
            return _categories;
        }
        public static Category? GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                //    return category; // this is the actual copy but to mimic database, we return a copy of this object
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return null;

        }
        public static void UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId) return;
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }

        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
