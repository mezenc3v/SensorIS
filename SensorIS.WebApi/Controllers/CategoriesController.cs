using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SensorIS.WebApi.Abstract;
using SensorIS.WebApi.Models;
using SensorIS.WebApi.Views;

namespace SensorIS.WebApi.Controllers
{
    [RoutePrefix("api/v1/categories")]
    [EnableCors("*", "*", "*")]
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesController(ICategoriesRepository repo)
        {
            _repository = repo;
        }
        public CategoriesController()
        {
            _repository = new CategoryRepository();
        }
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IEnumerable<CategoryView> GetCategories()
        {
            return _repository.GetCategories;
        }

        /// <summary>
        /// Get all products belonging to the category
        /// </summary>
        /// <param name="id">category id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IEnumerable<SensorView> GetSensors(int id)
        {
            var sensors = _repository.GetCategorySensors(id);
            return sensors;
        }
        /// <summary>
        /// create category
        /// </summary>
        /// <param name="category">the category you want to create</param>
        /// <returns>created category</returns>
        [HttpPost]
        [Route("")]
        public CategoryView AddCategory([FromBody]CategoryView category)
        {
            var newCategory = _repository.AddCategory(category);
            return newCategory;
        }
        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="categoryId">the category id you want to delete</param>
        [HttpDelete]
        [Route("{categoryId}")]
        public void DeleteCategory(int categoryId)
        {
            _repository.DeleteCategory(categoryId);
        }
    }
}

