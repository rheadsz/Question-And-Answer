using Exercises.DecisionTree;
using ExtensionMethods;
using static Exercises.DecisionTree.TerminalQuestion;

namespace DecisionTreeApp
{
    public class TreeTest
    {
        public static void Main(string[] args)
        {
            Question I = "That means you are a great programmer!".Boolean(Success, Failure);
            Question J = "Okay, Pack your bag".Boolean(Success, Failure);
            Question H = "How do you rate yourself in programming?".Range(Success.UpTo(0).Question(Success).UpTo(3).Question(J).UpTo(7).Question(I).UpTo(10).Otherwise(Failure));
            Question D = "Are you Rayan?".Boolean(Success, Failure);
            Question C = "Are you boy?".Boolean(Success, Failure);
            Question A = "Are you married?".Boolean(C, D);
            Question B = "Do you have kids?".Boolean(A, Failure);
            Question G = "Whats Your Name?".MultiQuestion(Success, "Arun".Question(H), "Mrinal".Question(I), "Rayan".Question(J));
            Question F = "Whats your age?".Numeric(G);
            Question E = "Are you human?".Boolean(F, B);


            Question currentQuestion = E;

            while (currentQuestion is not TerminalQuestion)
            {
              try
                {
                    Console.WriteLine(currentQuestion.GetQuestionText());
                    object reply = GetUserInput(currentQuestion);
                    currentQuestion.Be(reply);
                 
                    currentQuestion = currentQuestion.NextQuestion();
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            Console.WriteLine("You are Done. Thank you");
        }
        private static object GetUserInput(Question question)
        {
            string userInput = Console.ReadLine();
            return question.ParseUserInput(userInput);
        }
    }
}

