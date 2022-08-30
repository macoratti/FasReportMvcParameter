using FastReportMvcParameter.Models;

namespace FastReportMvcParameter.Services;

public class DataService : IDataService
{
    private readonly AppDbContext _context;
    public DataService(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        var products = _context.Products.ToList();
        return products;
    }

    public List<Category> GetCategories()
    {
        var categories = _context.Categories.ToList();
        return categories;
    }

    public Category GetCategoryById(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryID == id);
        return category;
    }    
}
