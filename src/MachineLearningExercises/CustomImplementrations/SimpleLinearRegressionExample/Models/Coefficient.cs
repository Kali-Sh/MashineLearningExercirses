namespace MachineLearningExercises.CustomImplementrations
{
    public class Coefficient : IEquatable<Coefficient>
    {
        public Coefficient() { }

        public Coefficient(double value)
        {
            Value = value;
        }

        public double Value { get; private set; }

        public bool Equals(Coefficient other)
        {
            return Value == other.Value;
        }
    }
}
