using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD {
    class Program {
        static void Main(string[] args) {

            var culture = CultureInfo.CreateSpecificCulture("ru-Ru");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages_ruRu", typeof(Program).Assembly);            

            Console.WriteLine(resourceManager.GetString("Hello"));            

            Console.WriteLine(resourceManager.GetString("EnterName"));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser) {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true) {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести приём пищи: ");
                Console.WriteLine("A - ввести упражнение: ");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key) {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods) {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises) {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadKey();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise() {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход енергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating() {
            Console.Write("Введите имя продукта: ");
            var foodName = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            var product = new Food(foodName, calories, proteins, fats, carbohydrates);

            return (product, weight);
        }

        private static DateTime ParseDateTime(string value) {
            DateTime birthDate;
            while (true) {
                Console.Write($"Введите {value} (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate)) {
                    break;
                }
                else {
                    Console.WriteLine($"Неверный формат {value}");
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
