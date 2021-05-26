using System.Collections.Immutable;
using SIMSA.Models;

namespace SIMSA.ViewModels
{
	public class PrimesVM : ViewModelBase
	{
		int upperBound;
		ImmutableArray<int> primes;
		public string Output => primes.Cat(", ");
		public int Count => primes.Length;
		public int UpperBound
		{
			get => upperBound;
			set
			{
				upperBound = value;
				ChangeProperty(ref primes, upperBound.AllLowerPrimes(), "UpperBound", "Output", "Count");
			}
		}
		public PrimesVM() : base(Config.Initial) { }
	}
}
