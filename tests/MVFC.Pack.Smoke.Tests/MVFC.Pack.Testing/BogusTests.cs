namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Testing;

public sealed class BogusTests
{
    [Fact]
    public void Bogus_Types_Should_Be_Accessible()
    {
        typeof(Faker).Should().NotBeNull();
        typeof(Faker<>).Should().NotBeNull();
        typeof(Name).Should().NotBeNull();
    }

    [Fact]
    public void Bogus_Should_Generate_Data_At_Runtime()
    {
        var faker = new Faker("pt_BR");
        var name = faker.Person.FullName;

        name.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Bogus_Should_Generate_Typed_Fake_Objects()
    {
        var faker = new Faker<SampleProduct>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000));

        var products = faker.Generate(10);

        products.Should().HaveCount(10);
        products.Should().AllSatisfy(p =>
        {
            p.Id.Should().NotBeEmpty();
            p.Name.Should().NotBeNullOrWhiteSpace();
            p.Price.Should().BeGreaterThan(0);
        });
    }

    public sealed class SampleProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
