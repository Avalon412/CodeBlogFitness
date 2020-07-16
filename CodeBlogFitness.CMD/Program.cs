using CodeBlogFitness.BL.Controller;
using System;

namespace CodeBlogFitness.CMD {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Вас приветствует приложение CodeBlogeFitness");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser) {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadKey();
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
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }
    }
}
