using System.Data.SqlClient;


//await PoolingBehaviour();
//await MinPoolSizeAsync();
//await MaxPoolSizeAsync();
await WithoutConnectionCloseAsync();
Console.ReadLine();


async Task PoolingBehaviour()
{
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;");
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;");

    //Veritabanı bağlantısı aynı olmasına rağmen Server bilgisi "MSSQLLocalDb"(sonu Db şeklinde) olduğu için yeni connection pool oluşturur
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDb;Database=ConnectionPool;Trusted_Connection=True;");

    SqlConnection.ClearAllPools();

    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDb;Database=ConnectionPool;Trusted_Connection=True;Pooling=false;");
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDb;Database=ConnectionPool;Trusted_Connection=True;Pooling=false;");
}

async Task MinPoolSizeAsync()
{
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True; Min Pool Size = 10;");
}

async Task MaxPoolSizeAsync()
{
    var list = new List<Task>();

    for (int i = 0; i < 6; i++)
    {
        list.Add(ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True; Max Pool Size = 5;"));
    }

    await Task.WhenAll(list);
}

async Task WithoutConnectionCloseAsync()
{
    for (int i = 0; i < 10; i++)
    {
        var connection = new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;");
        await connection.OpenAsync();
    }

    for (int i = 0; i < 10; i++)
    {
        try
        {
            var connection = new SqlConnection(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;");
            await connection.OpenAsync();
            throw new Exception();
        }
        catch (Exception)
        {

        }
    }
}

async Task ConnectAsync(string connectionString)
{
    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();
    await Task.Delay(1000);
}