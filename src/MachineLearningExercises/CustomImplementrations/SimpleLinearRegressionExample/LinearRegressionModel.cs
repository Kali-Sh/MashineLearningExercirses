using MachineLearningExercises.CustomImplementrations.SimpleLinearRegressionExample.Models;

namespace MachineLearningExercises.CustomImplementrations
{
    public class LinearRegressionModel : IModel<Observation, Result>
    {
        private double _meanOfX;
        private double _meanOfY;
        private double _slope;
        private double _intercept;
        private double _RSquared;

        public LinearRegressionModel() { }

        public double Intercept => _intercept;
        public double Slope => _slope;
        public double RSquared => _RSquared;

        public void Fit(IEnumerable<Observation> observations)
        {
            var observationsList = observations.ToList();

            _meanOfX = GetMeanOfX(observationsList.Select(x => x.X).ToArray());
            _meanOfY = GetMeanOfY(observationsList.Select(x => x.Y).ToArray());

            // b1 -> Σ((x-x̄)*(y-ȳ))/Σ(x-x̄)^2
            _slope = CalculateSlope(observationsList);

            // y = mx+b => b = y-mx , where m is the slope of the regression (regression coefficient)
            _intercept = _meanOfY - _slope * _meanOfX;
            _RSquared = CaluculateCoefficientOfDetermination(observationsList);
        }

        public Result Predict(Observation value) => new Result(Intercept + Slope * value.X);

        private double GetMeanOfX(double[] x) => x.Average();

        private double GetMeanOfY(double[] y) => y.Average();

        private double CalculateSlope(List<Observation> observations)
        {
            // Σ((x-x̄)*(y-ȳ))
            double sumDeviationMultipliedByResildual = 0;

            // Σ(x-x̄)^2
            double sumDeviationScoreSquared = 0;

            for (int i = 0; i < observations.Count(); i++)
            {
                Observation observation = observations[i];

                sumDeviationMultipliedByResildual += (observation.X - _meanOfX) * (observation.Y - _meanOfY);
                sumDeviationScoreSquared += Math.Pow((observation.X - _meanOfX), 2);
            }

            if (sumDeviationScoreSquared.Equals(0))
                throw new ArgumentNullException();

            return sumDeviationMultipliedByResildual / sumDeviationScoreSquared;
        }

        private double CaluculateCoefficientOfDetermination(List<Observation> observations)
        {
            // R^2 = Σ(ŷ-ȳ)/Σ(y-ȳ)
            double sumActualResidual = 0;
            double sumPredictedResidual = 0;

            for (int i = 0; i < observations.Count(); i++)
            {
                Observation observation = observations[i];

                sumActualResidual += Math.Pow((observation.Y - _meanOfY), 2);
                sumPredictedResidual += Math.Pow(((_slope * observation.X + _intercept) - _meanOfY), 2);
            }

            if (sumActualResidual.Equals(0))
                throw new ArgumentNullException();

            return sumPredictedResidual / sumActualResidual;
        }
    }
}
