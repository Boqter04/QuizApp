using System;
using System.Collections.Generic;
using System.Linq;
using QuizApplication.Models;

namespace Project2
{
    //Handles operations related to quizzes
    public class QuizService
    {
        // Private field to store the list of quizzes
        private readonly List<Quiz> quizzes;

        // Constructor to initialize the quizzes list and set up sample quizzes
        public QuizService()
        {
            quizzes = new List<Quiz>();
            SetUpSampleQuizzes();
        }

        // Method to add a quiz to the list
        public void AddQuiz(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new ArgumentNullException(nameof(quiz));
            }
            quizzes.Add(quiz);
        }

        // Method to get all quizzes
        public List<Quiz> GetAllQuizzes()
        {
            return new List<Quiz>(quizzes);
        }

        // Private method to set up sample quizzes
        private void SetUpSampleQuizzes()
        {
            var technologyQuestions = CreateTechnologyQuestions();
            var artQuestions = CreateArtQuestions();
            var mixedQuestions = technologyQuestions.Concat(artQuestions)
                                                    .OrderBy(_ => Guid.NewGuid())
                                                    .Take(20)
                                                    .ToList();

            // Add sample quizzes with different titles and question sets
            AddSampleQuiz("Technology", technologyQuestions);
            AddSampleQuiz("Art", artQuestions);
            AddSampleQuiz("Mixed", mixedQuestions);
            AddSampleQuiz("Back", new List<Question>()); // Empty quiz as a placeholder or back option
    }

        // Private method to add a sample quiz with given title and questions
        private void AddSampleQuiz(string title, List<Question> questions)
        {
            var quiz = new Quiz(title, questions);
            AddQuiz(quiz);
        }

        private List<Question> CreateTechnologyQuestions()
        {
            return new List<Question>
            {
                new Question("Which programming language is often used for web development?",
                             new List<string> { "Java", "JavaScript", "Python", "C#" },
                             new List<int> { 2 }),
                new Question("What does CPU stand for?",
                             new List<string> { "Central Processing Unit", "Central Process Unit", "Computer Personal Unit", "Central Processor Unit" },
                             new List<int> { 1 }),
                new Question("What is the name of the first electronic general-purpose computer?",
                             new List<string> { "ENIAC", "UNIVAC", "IBM PC", "Apple I" },
                             new List<int> { 1 }),
                new Question("Who is known as the father of the computer?",
                             new List<string> { "Alan Turing", "Charles Babbage", "John von Neumann", "Bill Gates" },
                             new List<int> { 2 }),
                new Question("What is the most popular operating system in the world?",
                             new List<string> { "MacOS", "Linux", "Windows", "Android" },
                             new List<int> { 3 }),
                new Question("What does HTTP stand for?",
                             new List<string> { "HyperText Transfer Protocol", "HyperText Transmission Protocol", "Hyper Transfer Text Protocol", "HyperText Translate Protocol" },
                             new List<int> { 1 }),
                new Question("Which company developed the Java programming language?",
                             new List<string> { "Microsoft", "Google", "Sun Microsystems", "IBM" },
                             new List<int> { 3 }),
                new Question("What is the main function of an operating system?",
                             new List<string> { "To run applications", "To manage hardware resources", "To connect to the internet", "To provide security" },
                             new List<int> { 2 }),
                new Question("What does GPU stand for?",
                             new List<string> { "General Processing Unit", "Graphics Processing Unit", "Graphical Process Unit", "Graph Processing Unit" },
                             new List<int> { 2 }),
                new Question("What is the name of Apple's programming language introduced in 2014?",
                             new List<string> { "Swift", "Objective-C", "Kotlin", "C++" },
                             new List<int> { 1 })
            };
        }

        private List<Question> CreateArtQuestions()
        {
            return new List<Question>
            {
                new Question("Who painted the Mona Lisa?",
                             new List<string> { "Vincent Van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Claude Monet" },
                             new List<int> { 3 }),
                new Question("What is the art of folding paper into shapes called?",
                             new List<string> { "Origami", "Kirigami", "Papercraft", "Quilling" },
                             new List<int> { 1 }),
                new Question("Who painted the ceiling of the Sistine Chapel?",
                             new List<string> { "Michelangelo", "Raphael", "Donatello", "Leonardo" },
                             new List<int> { 1 }),
                new Question("What style of art is Salvador Dali known for?",
                             new List<string> { "Cubism", "Surrealism", "Impressionism", "Fauvism" },
                             new List<int> { 2 }),
                new Question("What museum is the Mona Lisa located in?",
                             new List<string> { "Metropolitan Museum of Art", "Louvre", "British Museum", "Vatican Museums" },
                             new List<int> { 2 }),
                new Question("Which artist is known for the painting 'Starry Night'?",
                             new List<string> { "Vincent Van Gogh", "Claude Monet", "Pablo Picasso", "Henri Matisse" },
                             new List<int> { 1 }),
                new Question("What movement is associated with artists like Claude Monet and Edgar Degas?",
                             new List<string> { "Surrealism", "Impressionism", "Expressionism", "Cubism" },
                             new List<int> { 2 }),
                new Question("Which artist is known for the sculpture 'David'?",
                             new List<string> { "Donatello", "Michelangelo", "Bernini", "Rodin" },
                             new List<int> { 2 }),
                new Question("Which artist painted 'The Persistence of Memory'?",
                             new List<string> { "Pablo Picasso", "Salvador Dali", "Henri Matisse", "Paul Klee" },
                             new List<int> { 2 }),
                new Question("What is the term for a painting made on wet plaster?",
                             new List<string> { "Fresco", "Mosaic", "Collage", "Tapestry" },
                             new List<int> { 1 })
            };
        }
    }
}
