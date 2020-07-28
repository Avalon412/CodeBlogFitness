using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller {

    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase {
        private const string USERS_FILE_NAME = "users.dat";
        /// <summary>
        /// Cписок всех пользователей приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь приложения.
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание пользователя приложения.
        /// </summary>
        /// <param name="user"> Пользователь приложения. </param>
        public UserController(string userName) {

            if (string.IsNullOrWhiteSpace(userName)) {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);            

            if (CurrentUser == null) {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData() {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1) {
            if (string.IsNullOrWhiteSpace(genderName)) {
                throw new ArgumentNullException("Пол не может быть пустым или null.", nameof(genderName));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now) {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save() {
            Save(Users);
        }
    }
}
