using Allegory.Standart.Filter.Concrete;
using BasicExample;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var people = new List<Person>
{
    new Person("Kelly", "Pitts", new DateTime(1980, 1, 1), Gender.Male, 1500),
    new Person("Anne", "Henry", new DateTime(1981, 1, 1), Gender.Female, 2000),
    new Person("Ashton", "Rangel", new DateTime(1982, 1, 1), Gender.Male, 2500),
    new Person("Charley", "Atkinson", new DateTime(1983, 1, 1), Gender.Female, 3000),
    new Person("Anne", "Huff", new DateTime(1984, 1, 1), Gender.Female, 3500)
};

app.MapPost("/person/list",
    (FilteredRequest input) =>
    {
        var lambdaExpression = input.Conditions.ToLambdaExpression<Person>();
        return lambdaExpression == null ? people : people.Where(lambdaExpression);
    });

app.Run();