

namespace Exercises.DecisionTree;
public class NumericQuestion:Question
{
    private string _question;
    private readonly Question _answer;
    private int? _reply=null;
    public NumericQuestion(string question, Question answer)
    {
        _question = question;
        _answer = answer;
    }
    public void Be(object reply)
    {
        _reply = (int)reply;
    }
    public Question NextQuestion()
    {
        if (_reply == null) return this;
        return _answer.NextQuestion();
    }

    string Question.GetQuestionText()
    {
        return _question;
    }

    public object ParseUserInput(string? userInput)
    {
        if (int.TryParse(userInput, out int result))
        {
            return result;
        }
        throw new ArgumentException("Invalid input. Please enter a valid numeric value.");
    }
}