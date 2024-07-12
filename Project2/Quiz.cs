using System.Collections.Generic;

namespace QuizApplication.Models
{
    //Represents a quiz with title and list of questions
    public class Quiz
    {
        // Property to store the title of the quiz.
        public string title { get; set; }

        // Property to store the list of questions in the quiz.
        public List<Question> Questions { get; set; }

        // Constructor to initialize a new Quiz object with a title and a list of questions.
        public Quiz(string title, List<Question> questions)
        {
            this.title = title;
            Questions = questions;
        }
    }
}
