# Basic Example
This is a basic example project that demonstrates how to filter a list of people using various conditions.
Instead of creating DTO models for fields to be filtered, it allows us to define conditions according to our needs within a single endpoint.

## Quick Start
Add [Allegory.Standart.Filter](https://www.nuget.org/packages/Allegory.Standart.Filter) package from NuGet.
You can use the `Condition` class to create conditions for filtering. Here's an example:
- The first parameter represents the property to be filtered.
- The second parameter specifies the filter operator.
- The third parameter defines the filtered value.
- The fourth parameter defines to negate the operator.
```csharp
var condition = new Condition(nameof(Person.Name), Operator.Contains, value: "he", not: false);
```
We can also group conditions together. Here's an example:
- The first parameter represents a list of conditions.
- The second parameter specifies if any of the conditions should be met.
- The third parameter specifies if the operator should be negated.
```csharp
var conditions = new Condition(new List<Condition>
		{
			new Condition(nameof(Person.Name), Operator.Equals, "Henry"),
			new Condition(nameof(Person.Balance), Operator.IsGreaterThan, 1500),
			new Condition(nameof(Person.Surname), Operator.IsNullOrEmpty)
		},
		groupOr: false,
		not: false);
```
The all available operators that can be used for filtering:
```csharp
public enum Operator
{
  Equals = 0,
  DoesntEquals = 1,
  IsGreaterThan = 2,
  IsGreaterThanOrEqualto = 3,
  IsLessThan = 4,
  IsLessThanOrEqualto = 5,
  IsBetween = 6,
  Contains = 7,
  StartsWith = 8,
  EndsWith = 9,
  IsNull = 10,
  IsNullOrEmpty = 11,
  In = 12
}
```
Last but not least, we can also retrieve an expression or lambda expression from the conditions. Here's an example:
- We can use the `ToExpression<>` method with EF Core or any method that takes an `Expression<Func<T, bool>>`.
- We can use the `ToLambdaExpression<>` method with `IEnumerable` or any method that takes `Func<T, bool>`.
```csharp
Expression<Func<Person, bool>> expression = conditions.ToExpression<Person>();
var people = await personRepository.ListAsync(expression);

Func<Person, bool> lambdaExpression = conditions.ToLambdaExpression<Person>();
var filteredPeople = people.Where(lambdaExpression);
```

## References
- You can find a sample requests in the [folder](https://github.com/allegorysoft/practice/tree/main/lessons/csharp/1-Dinamik%20Filtreleme/BasicExample/BasicExample/Requests).
- The source code is available in the [library repository](https://github.com/allegorysoft/library/tree/main/allegory/framework/src/Allegory.Standart.Filter)
