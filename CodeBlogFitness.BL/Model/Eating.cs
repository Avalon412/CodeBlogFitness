using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model {

    /// <summary>
    /// Приём пищи.
    /// </summary>
    [Serializable]
    public class Eating {

        public int Id { get; set; }

        /// <summary>
        /// Момент приёма пищи.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Список еды и её употреблённого количества.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public virtual User User { get; set; }

        public Eating() { }

        /// <summary>
        /// Создать процес потребления пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public Eating(User user) {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавить потребленную пищу и её вес в список.
        /// </summary>
        /// <param name="food"> Наименование. </param>
        /// <param name="weight"> Вес. </param>
        public void Add(Food food, double weight) {            
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null) {
                Foods.Add(food, weight);
            }
            else {
                Foods[product] += weight;
            }
        }
    }
}
