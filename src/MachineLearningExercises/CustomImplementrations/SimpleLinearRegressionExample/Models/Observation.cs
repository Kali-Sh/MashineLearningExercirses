namespace MachineLearningExercises.CustomImplementrations.SimpleLinearRegressionExample.Models
{
    public class Observation : IEquatable<Observation>, ILeraningData
    {
        public Observation(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Observation(double x)
        {
            X = x;
        }

        public double X { get; private set; }

        public double Y { get; private set; }

        public bool Equals(Observation other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}
