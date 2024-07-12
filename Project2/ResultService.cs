using System.Collections.Generic;
using Project2;
using QuizApplication.Models;

namespace Project2
{
    // Handles operations related to quiz results
    public class ResultService
    {
        public void AddResult(User user, Result result)
        {
            user.Results.Add(result);
        }

        public List<Result> GetUserResults(User user)
        {
            return user.Results;
        }

        public List<Result> GetTopResults(string quizTitle)
        {
            // Implement logic to get top 20 results for a specific quiz
            return new List<Result>();
        }
    }
}
