

namespace Exercises.DecisionTree;

public class TerminalQuestion : Question
{
    public static TerminalQuestion Success = new TerminalQuestion();
    public static TerminalQuestion Failure = new TerminalQuestion();

    public void Be(object reply) => throw new InvalidOperationException("No More Questions, You are done");

    public string GetQuestionText()
    {
        return ((Question)Success).GetQuestionText();
    }

    public Question NextQuestion() => this;

    public object ParseUserInput(string? userInput)
    {
        return ((Question)Success).ParseUserInput(userInput);
    }
}