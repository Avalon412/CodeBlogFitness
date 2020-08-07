using System;

namespace CodeBlogFitness.BL.Model {
    [Serializable]
    public class Exercise {

        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user) {            

            if (start == null) {
                throw new ArgumentNullException("Время начала не может быть null", nameof(start));
            }

            if (finish == null) {
                throw new ArgumentNullException("Время окончания не может быть null", nameof(finish));
            }

            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активность не может быть null", nameof(activity));
            User = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));
        }

        public override string ToString() {
            return Activity.ToString();
        }
    }
}
