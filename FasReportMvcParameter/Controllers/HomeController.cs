using FastReport.Data;
using FastReport.Web;
using FastReportMvcParameter.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FasReportMvcParameter.Controllers;

public class HomeController : Controller
{
    public readonly IWebHostEnvironment _webHostEnv;
    private readonly IDataService _dataService;
    private readonly IConfiguration _config;

    public HomeController(IWebHostEnvironment webHostEnv, IDataService dataService,
        IConfiguration config)
    {
        _webHostEnv = webHostEnv;
        _dataService = dataService;
        _config = config;
    }

    public IActionResult ProductsByCategory(int CategoryID)
    {
        //criamos uma instancia do objeto webreport
        var webReport = new WebReport();
        webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath,
                            "wwwroot/reports", "ProductsCategory.frx"));

        // Obtemos uma instância do objeto MsSqlDataConnection
        // e definimos a string de conexão para o banco de dados nele
        var mssqlDataConnection = new MsSqlDataConnection();
        mssqlDataConnection.ConnectionString =
               _config.GetConnectionString("DefaultConnection");
        //obtemos e definimos os valores para os parâmetros usados         
        var conn = mssqlDataConnection.ConnectionString;
        webReport.Report.SetParameterValue("Conn", conn);
        webReport.Report.SetParameterValue("CategoryId", CategoryID);

        var categoryName = GetCategoryName(CategoryID);
        webReport.Report.SetParameterValue("CategoryName", categoryName);

        //exibimos o relatorio
        return View(webReport);
    }
    public string GetCategoryName(int id)
    {
        var category = _dataService.GetCategoryById(id);
        return category.CategoryName;
    }


    public IActionResult Index()
    {
        ViewBag.Categories =
          new SelectList(_dataService.GetCategories(), "CategoryID", "CategoryName");

        return View();
    }
}