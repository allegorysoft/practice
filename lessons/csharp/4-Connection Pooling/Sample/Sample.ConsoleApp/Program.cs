using System.Data.SqlClient;


await PoolingBehaviour();
Console.ReadLine();


async Task PoolingBehaviour()
{
    string connectionString = @"Server=(LocalDb)\MSSQLLocalDB;Database=ConnectionPool;Trusted_Connection=True;";

    await ConnectAsync(connectionString);
    await ConnectAsync(connectionString);

    //Veritabanı bağlantısı aynı olmasına rağmen Server bilgisi "MSSQLLocalDb"(sonu Db şeklinde) güncellendiğinde yeni connection pool oluşturuyor
    connectionString = @"Server=(LocalDb)\MSSQLLocalDb;Database=ConnectionPool;Trusted_Connection=True;";
    await ConnectAsync(connectionString);
}

async Task ConnectAsync(string connectionString)
{
    using SqlConnection connection = new SqlConnection(connectionString);
    await connection.OpenAsync();
}