using MachineLearningExercises.CustomImplementrations;
using MachineLearningExercises.CustomImplementrations.SimpleLinearRegressionExample.Models;

public class Program
{
    static void Main(string[] args)
    {
        LinearRegressionModel model = new LinearRegressionModel();
        var observations = new List<Observation> { new Observation(1, 2), new Observation(2, 4), new Observation(3, 5), new Observation(4, 4), new Observation(5, 5) };
        model.Fit(observations);

        //should be 2.8
        var predictedValue = model.Predict(new Observation(1));

        //should be 0.6
        var rqsuared = model.RSquared;
    }

    internal static List<Observation> GetSomeRandomObservations()
    {
        Random random = new Random(420);
        var observations = new List<Observation>();

        for (int i = 0; i < 10; i++)
        {
            observations.Add(new Observation(random.Next(1, 10), random.Next(1, 10)));
        }

        return observations;
    }
}