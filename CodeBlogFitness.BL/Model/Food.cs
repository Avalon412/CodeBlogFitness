using System;

namespace CodeBlogFitness.BL.Model {
    public class Food {
        #region Свойства
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории на 100 грамм.
        /// </summary>
        public double Calories { get; }

        private double CalloriesOneGram { get { return Calories / 100.0; } }

        private double ProteinsOneGram { get { return Proteins / 100.0; } }

        private double FatsOneGram { get { return Fats / 100.0; } }

        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }
        #endregion

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates) {
            #region Проверки
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentNullException("Название продукта не может быть пустым или null.", nameof(name));
            }

            if (calories < 0) {
                throw new ArgumentException("Калории не могут быть меньше 0.", nameof(calories));
            }

            if (proteins < 0) {
                throw new ArgumentException("Белки не могут быть меньше 0.", nameof(proteins));
            }

            if (fats < 0) {
                throw new ArgumentException("Жиры не могут быть меньше 0.", nameof(fats));
            }

            if (carbohydrates < 0) {
                throw new ArgumentException("Углеводы не могут быть меньше 0.", nameof(carbohydrates));
            }
            #endregion

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString() {
            return Name;
        }
    }
}
