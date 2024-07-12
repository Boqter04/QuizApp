using QuizApplication.Models;

namespace Project2 // Replace 'Project2' with your actual namespace if different
{
    // The QuestionService class provides functionality to manage questions within quizzes.
    public class QuestionService
    {
        // Method to add a question to a quiz.
        public void AddQuestion(Quiz quiz, Question question)
        {
            if (question != null && question != null)
            {
                quiz.Questions.Add(question);
            }
        }
    }
}
