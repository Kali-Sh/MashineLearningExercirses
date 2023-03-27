using MachineLearningExercises.CustomImplementrations.SimpleLinearRegressionExample.Models;

namespace MachineLearningExercises.CustomImplementrations
{
    interface IModel<TData, TPrediction> where TData : ILeraningData
        where TPrediction : IPredictionResult
    {
        void Fit(IEnumerable<TData> observations);

        TPrediction Predict(TData value);
    }
}
