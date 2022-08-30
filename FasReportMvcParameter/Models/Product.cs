namespace FastReportMvcParameter.Models;

public class Product
{
    public int ProductID { get; set; }
    public string? ProductName { get; set; }
    public Int16 UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
    public int CategoryID { get; set; }
}
