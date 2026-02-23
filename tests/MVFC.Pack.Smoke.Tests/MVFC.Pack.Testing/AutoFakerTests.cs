namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Testing;

public sealed class AutoFakerTests
{
    [Fact]
    public void AutoFaker_Types_Should_Be_Accessible()
    {
        typeof(AutoFaker).Should().NotBeNull();
        typeof(AutoFaker<>).Should().NotBeNull();
    }

    [Fact]
    public void AutoFaker_Should_Generate_Typed_Fake_Objects_Automatically()
    {
        var faker = new AutoFaker<ComplexTarget>();
        
        var targets = faker.Generate(10);

        targets.Should().HaveCount(10);
        targets.Should().AllSatisfy(t =>
        {
            t.Id.Should().NotBeEmpty();
            t.Name.Should().NotBeNullOrWhiteSpace();
            t.Value.Should().NotBe(default);
            t.NestedComplexType.Should().NotBeNull();
            t.NestedComplexType.Description.Should().NotBeNullOrWhiteSpace();
            t.Items.Should().NotBeNull();
            t.Items.Should().NotBeEmpty();
        });
    }

    public sealed class ComplexTarget
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public NestedType NestedComplexType { get; set; } = null!;
        public IList<string> Items { get; set; } = [];
    }

    public sealed class NestedType
    {
        public string Description { get; set; } = string.Empty;
    }
}
