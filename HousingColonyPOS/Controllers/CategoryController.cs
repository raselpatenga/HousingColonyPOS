using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousingColonyPOS.Data;
using HousingColonyPOS.Models;
using HousingColonyPOS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HousingColonyPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private CategoryService categoryService;
        public CategoryController(POSContext context)
        {
            categoryService = new CategoryService(context);
        }
        //Get api/category
        [HttpGet]
        public ActionResult<Category> GetAllCategory()
        {
            try
            {
                var list = categoryService.GetCategoryList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest($"Errore !!! This Warning {ex.Message}");
            }
        }
        //Post api/category
        [HttpPost]
        public ActionResult Post([FromBody] Category model)
        {
            try
            {
                var message = categoryService.CategorySave(model);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Category Save Unsuccess!! Errore this warning {ex.Message}");
            }
        }
        //Put api/category/1
        [HttpPut("{id}")]
        public ActionResult Put(int Id, [FromBody] Category model)
        {
            try
            {
                var message = categoryService.UpdateCategory(Id, model);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Category update Unsuccess!! Errore this warning {ex.Message}");
            }
        }
        // Get api/category/1
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int Id)
        {
            try
            {
                var data = categoryService.GetCategoryInfo(Id);
                if (data == null)
                    return NotFound("Data not found !!");
                else
                    return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Category this errore!! With this warning {ex.Message}");
            }
        }

        //Delete api/category/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int Id)
        {
            try
            {
                var message = categoryService.DeleteCategory(Id);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Unsuccessfully Dalete!! {ex.Message}");
            }
        }
    }
}