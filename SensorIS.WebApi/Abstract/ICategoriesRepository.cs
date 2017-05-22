using System.Collections.Generic;
using SensorIS.WebApi.Views;

namespace SensorIS.WebApi.Abstract
{
    public interface ICategoriesRepository
    {
        IEnumerable<CategoryView> GetCategories { get; }

        IEnumerable<SensorView> GetCategorySensors(int categoryId);

        CategoryView AddCategory(CategoryView category);

        void DeleteCategory(int categoryId);
    }
}
