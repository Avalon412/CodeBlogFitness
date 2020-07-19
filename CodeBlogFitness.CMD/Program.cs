using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;

namespace CodeBlogFitness.CMD {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Вас приветствует приложение CodeBlogeFitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser) {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.Write("Е - ввести приём пищи: ");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E) {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods) {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadKey();
        }

        private static (Food Food, double Weight) EnterEating() {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fars = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            var product = new Food(foodName, calories, proteins, fars, carbohydrates);

            return (product, weight);
        }

        private static DateTime ParseDateTime() {
            DateTime birthDate;
            while (true) {
                Console.Write("Введите дату рождения (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate)) {
                    break;
                }
                else {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name) {
            while (true) {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value)) {
                    return value;
                }
                else {
                    Console.WriteLine($"Неверный формат поля '{name}'");
                }
            }
        }
    }
}
