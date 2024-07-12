using System.Collections.Generic;

namespace QuizApplication.Models
{
    //Represents a quiz question
    public class Question
    {

        // Property to store the text of the question.
        public string Text { get; set; }

        // Property to store the list of possible answer options.
        public List<string> Options { get; set; }

        // Property to store the list of indices representing the correct answers.
        public List<int> CorrectAnswers { get; set; }

        // Constructor to initialize 
        public Question(string text, List<string> options, List<int> correctAnswers)
        {
            Text = text;
            Options = options;
            CorrectAnswers = correctAnswers;
        }
    }
}
