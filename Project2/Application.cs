using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class Application
    {
        private static UserService userService = new UserService();
        private static QuizService quizService = new QuizService();
        private static ResultService resultService = new ResultService();
        static public void color()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void Run()
        {
            while (true)
            {
                Console.Clear();
                color();
                Console.WriteLine("\tLog In");
                Console.WriteLine("\t======");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        return;
                }
            }
        }

        private static void Login()
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var user = userService.Login(username, password);
            if (user != null)
            {
                UserMenu(user);
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }

        private static void Register()
        {
            Console.WriteLine("Enter username:");
            var username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            try
            {
                var user = userService.Register(username, password);
                Console.WriteLine("Registration successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void UserMenu(User user)
        {
            while (true)
            {
                Console.Clear();
                color();
                Console.WriteLine();
                Console.WriteLine("\tWelcome to Quiz Test");
                Console.WriteLine("\t--------------------");
                Console.WriteLine();
                Console.ResetColor();
                Console.WriteLine("1. Start New Quiz");
                Console.WriteLine("2. View Previous Results");
                Console.WriteLine("3. Change Settings");
                Console.WriteLine("0. Logout");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        StartQuiz(user);
                        break;
                    case "2":
                        ViewPreviousResults(user);
                        break;
                    case "3":
                        Console.Clear();
                        ChangeSettings(user);
                        break;
                    case "0":
                        return;
                }
            }
        }

        private static void StartQuiz(User user)
        {
            color();
            Console.WriteLine();
            Console.WriteLine("\tSelect a quiz:");
            Console.WriteLine("\t-------------");
            Console.WriteLine();
            Console.ResetColor();
            var quizzes = quizService.GetAllQuizzes();
            for (int i = 0; i < quizzes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quizzes[i].title}");
            }

            if (int.TryParse(Console.ReadLine(), out var choice) && choice > 0 && choice <= quizzes.Count)
            {
                var quiz = quizzes[choice - 1];
                if (quiz.title == "Back")
                {
                    return;
                }

                var correctAnswers = 0;
                foreach (var question in quiz.Questions)
                {
                    Console.WriteLine(question.Text);
                    for (int i = 0; i < question.Options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {question.Options[i]}");
                    }

                    if (int.TryParse(Console.ReadLine(), out var answer) && answer > 0 && answer <= question.Options.Count)
                    {
                        if (question.CorrectAnswers.Contains(answer))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct!");
                            Console.ResetColor();
                            Console.WriteLine();
                            correctAnswers++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid input. Please enter a number corresponding to one of the options.");
                        Console.ResetColor();
                    }
                }

                var points = correctAnswers * 5;
                var result = new Result(quiz.title, correctAnswers, DateTime.Now, points);
                resultService.AddResult(user, result);

                Console.WriteLine($"You answered {correctAnswers} out of {quiz.Questions.Count} questions correctly and earned {points} points.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewPreviousResults(User user)
        {
            var results = resultService.GetUserResults(user);
            if (results.Count == 0)
            {
                Console.WriteLine("No previous results found.");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine($"Quiz: {result.QuizTitle}, Correct Answers: {result.CorrectAnswers}, Points: {result.Points}, Date: {result.DateTaken}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ChangeSettings(User user)
        {
            Console.WriteLine("1. Change Password");
            Console.WriteLine("2. Back");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter new password:");
                var newPassword = Console.ReadLine();
                userService.ChangePassword(user, newPassword);
                Console.WriteLine("Password changed successfully.");
            }
        }
    }
}
