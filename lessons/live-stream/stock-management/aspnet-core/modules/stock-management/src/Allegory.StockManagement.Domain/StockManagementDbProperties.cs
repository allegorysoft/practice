namespace Allegory.StockManagement;

public static class StockManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "StockManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "StockManagement";
}
