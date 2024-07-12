using System;

namespace Project2
{
    public class Result
    {
        public string QuizTitle { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime DateTaken { get; set; }
        public int Points { get; set; }

        public Result(string quizTitle, int correctAnswers, DateTime dateTaken, int points)
        {
            QuizTitle = quizTitle;
            CorrectAnswers = correctAnswers;
            DateTaken = dateTaken;
            Points = points;
        }
    }
}
