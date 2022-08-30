using FastReportMvcParameter.Models;

namespace FastReportMvcParameter.Services;

public interface IDataService
{
    List<Product> GetProducts();
    List<Category> GetCategories();
    Category GetCategoryById(int id);
}
