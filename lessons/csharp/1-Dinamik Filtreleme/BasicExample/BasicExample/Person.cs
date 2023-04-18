namespace BasicExample;

public record Person(
    string name,
    string surname,
    DateTime birthDate,
    Gender gender,
    decimal balance);

public enum Gender
{
    Male,
    Female
}