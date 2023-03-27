namespace MachineLearningExercises.CustomImplementrations.SimpleLinearRegressionExample.Models
{
    public class Result : IPredictionResult
    {
        public Result(double predictedValue)
        {
            PredictedValue = predictedValue;
        }

        public double PredictedValue { get; private set; }
    }
}
