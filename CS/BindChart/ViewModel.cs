using System;
using System.Collections;
using System.Collections.Generic;

namespace BindChart {

    public class DateTimeDataPoint {
        public DateTime PointArgument { get; set; }
        public double PointValue { get; set; }
    }

    public class ViewModel {
        DateTime start = new DateTime(2000, 1, 1);
        IEnumerable itemsSource;
        readonly Random random = new Random();


        public TimeSpan Step { get; set; }
        public int Count { get; set; }
        public double Start { get; set; }
        public IEnumerable ItemsSource {
            get { return itemsSource ?? (itemsSource = CreateItemsSource(Count)); }
        }

        protected IEnumerable CreateItemsSource(int count) {
            var points = new List<DateTimeDataPoint>();

            double value = GenerateStartValue(random);
            points.Add(new DateTimeDataPoint() { PointArgument = start, PointValue = value });
            for (int i = 1; i < count; i++) {
                value += GenerateAddition(random);
                start = start + Step;
                points.Add(new DateTimeDataPoint() { PointArgument = start, PointValue = value });
            }
            return points;
        }

        protected double GenerateStartValue(Random random) {
            return Start + random.NextDouble() * 100;
        }

        protected double GenerateAddition(Random random) {
            double factor = random.NextDouble();
            if (factor == 1)
                factor = 50;
            else if (factor == 0)
                factor = -50;
            return (factor - 0.5) * 50;
        }
    }
}
