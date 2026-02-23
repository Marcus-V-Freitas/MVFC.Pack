namespace MVFC.Pack.Smoke.Tests;

public sealed class MetapackageTestingSmokeTests
{
    [Fact]
    public void FluentAssertions_Types_Should_Be_Accessible()
    {
        typeof(FluentAssertions.AssertionOptions).Should().NotBeNull();
        typeof(FluentAssertions.Primitives.StringAssertions).Should().NotBeNull();
    }

    [Fact]
    public void NSubstitute_Types_Should_Be_Accessible()
    {
        typeof(NSubstitute.Substitute).Should().NotBeNull();
        typeof(NSubstitute.Arg).Should().NotBeNull();
    }

    [Fact]
    public void Bogus_Types_Should_Be_Accessible()
    {
        typeof(Bogus.Faker).Should().NotBeNull();
        typeof(Bogus.Faker<>).Should().NotBeNull();
        typeof(Bogus.DataSets.Name).Should().NotBeNull();
    }

    [Fact]
    public void Testcontainers_Types_Should_Be_Accessible()
    {
        typeof(DotNet.Testcontainers.Containers.IContainer).Should().NotBeNull();
        typeof(DotNet.Testcontainers.Configurations.IContainerConfiguration).Should().NotBeNull();
    }

    [Fact]
    public void MvcTesting_Types_Should_Be_Accessible()
    {
        typeof(Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<>).Should().NotBeNull();
    }

    [Fact]
    public void NSubstitute_Should_Create_Substitute_At_Runtime()
    {
        var fake = NSubstitute.Substitute.For<IDisposable>();

        fake.Should().NotBeNull();
    }

    [Fact]
    public void Bogus_Should_Generate_Data_At_Runtime()
    {
        var faker = new Bogus.Faker("pt_BR");
        var name = faker.Person.FullName;

        name.Should().NotBeNullOrWhiteSpace();
    }
}

