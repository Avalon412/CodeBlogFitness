using System;

namespace CodeBlogFitness.BL.Model {
    [Serializable]
    public class Activity {

        public string Name { get; }

        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute) {
            //TODO: Проверки

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString() {
            return Name;
        }
    }
}
