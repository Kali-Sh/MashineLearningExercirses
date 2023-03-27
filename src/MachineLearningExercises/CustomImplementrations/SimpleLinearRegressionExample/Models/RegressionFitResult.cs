namespace MachineLearningExercises.CustomImplementrations
{
    public class RegressionFitResult
    {
        public RegressionFitResult(Coefficient intercept, Coefficient slope, Coefficient coefficientOfDetermination)
        {
            Intercept = intercept;
            Slope = slope;
            CoefficientOfDetermination = coefficientOfDetermination;
        }

        public Coefficient Intercept { get; private set; }

        public Coefficient Slope { get; private set; }

        public Coefficient CoefficientOfDetermination { get; private set; }

        public static RegressionFitResult Create(Coefficient intercept, Coefficient slope, Coefficient coefficientOfDetermination) => new RegressionFitResult(intercept, slope, coefficientOfDetermination);
    }
}
