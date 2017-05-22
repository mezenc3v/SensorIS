using System.Collections.Generic;
using System.Linq;
using SensorIS.WebApi.Abstract;
using SensorIS.WebApi.Views;

namespace SensorIS.WebApi.Models
{
    public class CategoryRepository : ICategoriesRepository
    {
        readonly SensorsContext _context = new SensorsContext();

        public IEnumerable<CategoryView> GetCategories => _context.Categories.Select(cat => new CategoryView
        {
            CategoryId = cat.CategoryId,
            Image = cat.Image,
            Name = cat.Name
        });


        public IEnumerable<SensorView> GetCategorySensors(int categoryId)
        {
            var categorySensors = _context.Sensors.Where(p => p.CategoryId == categoryId).Select(sensor => new SensorView
            {
                Name = sensor.Name,
                SensorId = sensor.SensorId,
                ImageUrl = sensor.ImageUrl,
                CategoryId = sensor.CategoryId,
                Description = sensor.Description,
                DescriptionUrl = sensor.DescriptionUrl
            });

            return categorySensors;
        }

        public CategoryView AddCategory(CategoryView category)
        {
            var createdCategory = new Category
            {
                Image = category.Image,
                Name = category.Name
            };

            _context.Categories.Add(createdCategory);
            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(int categoryId)
        {
            var sensors = _context.Sensors.Where(sens => sens.CategoryId == categoryId);
            _context.Sensors.RemoveRange(sensors);
            var categoryToBeDeleted = _context.Categories.First(cat => cat.CategoryId == categoryId);
            _context.Categories.Remove(categoryToBeDeleted);
            _context.SaveChanges();
        }
    }
}