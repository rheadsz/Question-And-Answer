
namespace Exercises.DecisionTree;
public interface Question
{
    void Be(object reply);
    string GetQuestionText();
    Question NextQuestion();
    object ParseUserInput(string? userInput);
}