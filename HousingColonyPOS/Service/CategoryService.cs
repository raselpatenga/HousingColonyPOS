using HousingColonyPOS.Data;
using HousingColonyPOS.Models;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HousingColonyPOS.Service
{
    public class CategoryService
    {
        private POSContext _context;

        public CategoryService(POSContext context)
        {
            _context = context;
        }
        public List<Category> GetCategoryList()
        {
            try
            {
                var list = _context.Categories.ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string CategorySave(Category model)
        {
            try
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                var result = "Save Successfully";
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateCategory(int Id, Category model)
        {
            try
            {
                var OldCategory = _context.Categories.Find(Id);
                OldCategory.CategoryName = model.CategoryName;
                OldCategory.GroupId = model.GroupId;
                _context.SaveChanges();
                return "Update Successfully";                
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public Category GetCategoryInfo(int Id)
        {
            try
            {
                var CategoryInfo = _context.Categories.Where(x => x.CategoryId == Id).SingleOrDefault();
                return CategoryInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteCategory(int Id)
        {
            try
            {
                var isExistCategory = _context.Categories.Find(Id);
                if (isExistCategory == null)
                    throw new SystemException("This Category not found!! Please check Category List");
                _context.Categories.Remove(isExistCategory);
                _context.SaveChanges();
                return "Delete Successfully.";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
