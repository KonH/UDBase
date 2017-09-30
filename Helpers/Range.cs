using System;

namespace UDBase.Helpers {
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
			return string.Format("Range: [{0}, {1}]", Start, End);
		}
	}

	[Serializable]
	public class IntRange:Range<int> {

		public IntRange() {}

		public IntRange(int start, int end):base(start, end) {}

		public override bool IsValid() {
			return End > Start;
		}

		public override bool Contains(int value) {
			return (value >= Start) && (value <= End);
		}

		public override int Random() {
			return UnityEngine.Random.Range(Start, End);
		}

		public int RandomInclusive() {
			return UnityEngine.Random.Range(Start, End + 1);
		}
	}

	[Serializable]
	public class FloatRange:Range<float> {

		public FloatRange() {}

		public FloatRange(float start, float end):base(start, end) {}

		public override bool IsValid() {
			return End > Start;
		}

		public override bool Contains(float value) {
			return (value >= Start) && (value <= End);
		}

		public override float Random() {
			return UnityEngine.Random.Range(Start, End);
		}
	}
}
