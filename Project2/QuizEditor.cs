using Project2;
using QuizApplication.Models;

// The QuizEditor class provides functionality to edit quizzes and questions.
public class QuizEditor
{
    private QuizService quizService; // Private field to hold an instance of QuizService.
    private QuestionService questionService; // Private field to hold an instance of QuestionService.

    // Constructor to initialize a new QuizEditor object with dependencies on QuizService and QuestionService.
    public QuizEditor(QuizService quizService, QuestionService questionService)
    {
        this.quizService = quizService;
        this.questionService = questionService;
    }
}