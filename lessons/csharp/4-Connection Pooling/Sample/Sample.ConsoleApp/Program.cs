using System.Data.SqlClient;


//await PoolingBehaviour();
//await MinPoolSizeAsync();
//await MaxPoolSizeAsync();
await WithoutConnectionCloseAsync();
Console.ReadLine();

async Task PoolingBehaviour()
{
    //Bağlantılar havuzda bekletilir 4-8 dakika arasında tekrar kullanılmazsa zaman aşımına uğrar
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
    //Havuzda minimum belirtilen değer kadar sürekli bağlantıyı açık tutar(Örnek olarak minimum bağlantı sayısı 10 ise havuzda boşta 20 bağlantı varsa sadece 10 tanesini zaman aşımına uğratır)
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
    //!!! Açık kalan bağlantılar havuzda kulllanımda olarak tutulur zaman aşımına uğramazlar
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
            connection.Close();
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


/* SQL Queries
SELECT @@SPID as SessionID

SELECT 
    DB_NAME(dbid) as DBName, 
    COUNT(dbid) as NumberOfConnections,
    loginame as LoginName
FROM   sys.sysprocesses
WHERE 
    dbid > 0
GROUP BY 
    dbid, loginame;
 */