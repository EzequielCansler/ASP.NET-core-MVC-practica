namespace NehuenOrg.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{ CategoryId = 1 , CategoryName = "Fruta", CategoryDescription  = "Fruta" },
            new Category{ CategoryId = 2 , CategoryName = "Verdura", CategoryDescription  = "Verdura" },
            new Category{ CategoryId = 3 , CategoryName = "Almacen", CategoryDescription  = "Almacen" }

        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId++;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int CategoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == CategoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                };
            }
            return null;
        }

        public static void UpdateCategory(int CategoryId, Category category)
        {
            if (CategoryId != category.CategoryId) return;

            var categoryToUpdate = GetCategoryById(CategoryId);
            if(categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = category.CategoryName;
                categoryToUpdate.CategoryDescription = category.CategoryDescription;
            }
        }

        public static void DeleteCategory(int CategoryId)
        {
            var category = _categories.FirstOrDefault(x=>x.CategoryId == CategoryId);
            if(category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
