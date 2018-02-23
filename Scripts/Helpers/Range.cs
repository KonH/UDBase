using System;

namespace UDBase.Helpers {
	/// <summary>
	/// Base range helper class for work with values in specific range 
	/// </summary>
	public abstract class Range<T> {
		public T Start;
		public T End;

		protected Range() {}

		protected Range(T start, T end) {
			Start = start;
			End   = end;
		}

		public abstract bool IsValid();
		public abstract bool Contains(T value);
		public abstract T    Random();

		public override string ToString() {
			return $"Range: [{Start}, {End}]";
		}
	}

	/// <summary>
	/// Integer range helper class for work with values in specific range 
	/// </summary>
	[Serializable]
	public class IntRange:Range<int> {

		public IntRange() {}

		public IntRange(int start, int end):base(start, end) {}

		/// <summary>
		/// Returns true if range is valid (End &gt; Start)
		/// </summary>
		public override bool IsValid() {
			return End > Start;
		}

		/// <summary>
		/// Check that given value in Start &lt;= value &lt;= End
		/// </summary>
		public override bool Contains(int value) {
			return (value >= Start) && (value <= End);
		}

		/// <summary>
		/// Return value in Start &lt;= value &lt; End
		/// </summary>
		public override int Random() {
			return UnityEngine.Random.Range(Start, End);
		}

		/// <summary>
		/// Return value in Start &lt;= value &lt;= End
		/// </summary>
		public int RandomInclusive() {
			return UnityEngine.Random.Range(Start, End + 1);
		}
	}

	/// <summary>
	/// Float range helper class for work with values in specific range 
	/// </summary>
	[Serializable]
	public class FloatRange:Range<float> {

		public FloatRange() {}

		public FloatRange(float start, float end):base(start, end) {}

		/// <summary>
		/// Returns true if range is valid (End > Start)
		/// </summary>
		/// <returns></returns>
		public override bool IsValid() {
			return End > Start;
		}

		/// <summary>
		/// Check that given value in Start &lt;= value &lt;= End
		/// </summary>
		public override bool Contains(float value) {
			return (value >= Start) && (value <= End);
		}

		/// <summary>
		/// Return value in Start &lt;= value &lt; End
		/// </summary>
		public override float Random() {
			return UnityEngine.Random.Range(Start, End);
		}
	}
}
