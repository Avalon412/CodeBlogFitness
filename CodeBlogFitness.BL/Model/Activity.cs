using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model {
    [Serializable]
    public class Activity {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public double CaloriesPerMinute { get; set; }

        public Activity() { }

        public Activity(string name, double caloriesPerMinute) {            
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException("Имя не может быть пустым", nameof(name));
            }

            if (caloriesPerMinute <= 0) {
                throw new ArgumentException("Каллории не могут быть ниже или равны нулю", nameof(caloriesPerMinute));
            }

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString() {
            return Name;
        }
    }
}
