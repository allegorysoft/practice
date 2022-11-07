using System.Data.SqlClient;


await PoolingBehaviour();
Console.ReadLine();


async Task PoolingBehaviour()
{
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;");
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;");

    //Veritabanı bağlantısı aynı olmasına rağmen Server bilgisi "MSSQLLocalDb"(sonu Db şeklinde) olduğu için yeni connection pool oluşturur
    await ConnectAsync(@"Server=(LocalDb)\MSSQLLocalDb;Database=ConnectionPool;Trusted_Connection=True;");
}

async Task ConnectAsync(string connectionString)
{
    using SqlConnection connection = new SqlConnection(connectionString);
    await connection.OpenAsync();
}