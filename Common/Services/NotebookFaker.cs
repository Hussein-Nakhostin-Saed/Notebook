using Bogus;

namespace Common.Services;

public static class NotebookFaker
{
    private static readonly object _lock = new();
    private static Faker _faker = new("en");

    public static void SetSeed(int seed)
    {
        lock (_lock)
        {
            Randomizer.Seed = new Random(seed);
            _faker = new Faker("en");
        }
    }

    public static void ResetSeed()
    {
        lock (_lock)
        {
            Randomizer.Seed = new Random();
            _faker = new Faker("en");
        }
    }

    public static string FirstName() => _faker.Name.FirstName();
    public static string LastName() => _faker.Name.LastName();
    public static string FullName() => _faker.Name.FullName();
    public static string Email() => _faker.Internet.Email();
    public static string UserName() => _faker.Internet.UserName();
    public static string Password(int length = 12) => _faker.Internet.Password(length);
    public static string PhoneNumber() => _faker.Phone.PhoneNumber();
    public static string CompanyName() => _faker.Company.CompanyName();
    public static string JobTitle() => _faker.Name.JobTitle();
    public static string Address() => _faker.Address.FullAddress();
    public static string City() => _faker.Address.City();
    public static string Country() => _faker.Address.Country();
    public static string ZipCode() => _faker.Address.ZipCode();
    public static string Lorem(int words = 10) => _faker.Lorem.Sentence(words);
    public static string Paragraph() => _faker.Lorem.Paragraph();
    public static Guid Guid() => _faker.Random.Guid();
    public static int Number(int min = 1, int max = 1000) => _faker.Random.Int(min, max);
    public static decimal Money(decimal min = 10, decimal max = 10000) => _faker.Finance.Amount(min, max);
    public static DateTime PastDate(int yearsToGoBack = 5) => _faker.Date.Past(yearsToGoBack);
    public static DateTime FutureDate(int yearsToGoForward = 2) => _faker.Date.Future(yearsToGoForward);
    public static DateTime BirthDate(int minAge = 18, int maxAge = 65) => _faker.Date.Past(maxAge, DateTime.Today.AddYears(-minAge));
    public static bool Boolean() => _faker.Random.Bool();

    public static T Generate<T>(Action<Faker<T>>? configure = null) where T : class
    {
        var faker = new Faker<T>();
        configure?.Invoke(faker);
        return faker.Generate();
    }

    public static List<T> GenerateMany<T>(int count, Action<Faker<T>>? configure = null) where T : class
    {
        var faker = new Faker<T>();
        configure?.Invoke(faker);
        return faker.Generate(count);
    }

    public static NotebookUser GenerateUser()
    {
        return new Faker<NotebookUser>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.DateOfBirth, f => f.Date.Past(40, DateTime.Today.AddYears(-18)))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past(2))
            .Generate();
    }

    public static List<NotebookUser> GenerateUsers(int count)
    {
        return new Faker<NotebookUser>()
            .RuleFor(u => u.Id, f => f.Random.Guid())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.DateOfBirth, f => f.Date.Past(40, DateTime.Today.AddYears(-18)))
            .RuleFor(u => u.CreatedAt, f => f.Date.Past(2))
            .Generate(count);
    }
}
