using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;

public class Pet : Entity
{
	public string Name { get; init; } = string.Empty;
	public int Age { get; init; }
	public string Color { get; set; }
	public Weight Weight { get; init; }
	public SexOfPet Sex { get; set; }
	public BreedId BreedId { get; set; }

	public Pet(Guid id,
			string name,
			int age,
			string color,
			Weight weight,
			SexOfPet sex,
			BreedId breedId)
	{
		Id = id;
		Name = name;
		Age = age;
		Color = color;
		Weight = weight;
		Sex = sex;
		BreedId = breedId;
	}
}

public enum SexOfPet
{
	Male,
	Female
}