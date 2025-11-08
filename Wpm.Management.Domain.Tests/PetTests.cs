using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
	[Fact]
	public void Pet_should_be_equal()
	{
		var id = Guid.NewGuid();
		var breedService = new FakeBreedService();
		var breedId = new BreedId(breedService.breeds[0].Id, breedService);
		var pet1 = new Pet(id, "Name1", 10, "Brown", new Weight(5.0m), SexOfPet.Male, breedId);
		var pet2 = new Pet(id, "Name2", 5, "Black", new Weight(4.0m), SexOfPet.Female, breedId);

		Assert.True(pet1.Equals(pet2));
	}

	[Fact]
	public void Pet_should_be_equal_operator()
	{
		var id = Guid.NewGuid();
		var breedService = new FakeBreedService();
		var breedId = new BreedId(breedService.breeds[0].Id, breedService);
		var pet1 = new Pet(id, "Name1", 10, "Brown", new Weight(5.0m), SexOfPet.Male, breedId);
		var pet2 = new Pet(id, "Name2", 5, "Black", new Weight(4.0m), SexOfPet.Female, breedId);

		Assert.True(pet1 == pet2);
	}

	[Fact]
	public void Pet_should_not_be_equal_operator()
	{
		var id1 = Guid.NewGuid();
		var id2 = Guid.NewGuid();
		var breedService = new FakeBreedService();
		var breedId = new BreedId(breedService.breeds[0].Id, breedService);
		var pet1 = new Pet(id1, "Name1", 10, "Brown", new Weight(5.0m), SexOfPet.Male, breedId);
		var pet2 = new Pet(id2, "Name2", 5, "Black", new Weight(4.0m), SexOfPet.Female, breedId);

		Assert.True(pet1 != pet2);
	}

	[Fact]
	public void Weight_should_be_equal()
	{
		var weight1 = new Weight(5.0m);
		var weight2 = new Weight(5.0m);
		Assert.Equal(weight1.Value, weight2.Value);
	}

	[Fact]
	public void Weight_should_throw_exception_for_negative_value()
	{
		Assert.Throws<ArgumentException>(() => new Weight(-1.0m));
	}

	[Fact]
	public void WeightRange_should_be_equal()
	{
		var weightRange1 = new WeightRange(2.0m, 10.0m);
		var weightRange2 = new WeightRange(2.0m, 10.0m);
		Assert.Equal(weightRange1.From, weightRange2.From);
		Assert.Equal(weightRange1.To, weightRange2.To);
	}

	[Fact]
	public void BreedId_should_be_valid()
	{
		var breedService = new FakeBreedService();
		var validBreedId = breedService.breeds[0].Id;
		var breedId = new BreedId(validBreedId, breedService);
		Assert.Equal(validBreedId, breedId.Value);
	}

	[Fact]
	public void BreedId_should_not_be_valid()
	{
		var breedService = new FakeBreedService();
		var invalidBreedId = Guid.NewGuid();
		Assert.Throws<ArgumentException>(() => new BreedId(invalidBreedId, breedService));
	}
}
