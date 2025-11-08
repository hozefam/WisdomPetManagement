using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain
{
	public interface IBreedService
	{
		Breed? GetBreed(Guid id);
	}

	public class FakeBreedService : IBreedService
	{
		public readonly List<Breed> breeds = new()
		{
			new Breed(
				Guid.NewGuid(),
				"Beagle",
				new ValueObjects.WeightRange(10.0m, 20.0m),
				new ValueObjects.WeightRange(8.0m, 15.0m)
			),
			new Breed(
				Guid.NewGuid(),
				"Staffordshire Bull Terrier",
				new ValueObjects.WeightRange(15.0m, 25.0m),
				new ValueObjects.WeightRange(12.0m, 20.0m)
			)
		};

		public Breed? GetBreed(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentException("Breed is not valid");
			}

			var result = breeds.Find(b => b.Id == id);
			return result ?? throw new ArgumentException("Breed not found");
		}
	}
}
