
namespace Exercises.DecisionTree;
public class MultipleChoiceQuestion : Question
{
    private string _question;
    private readonly Question _defaultAnswer;
    private readonly List<Option> _options;
    private string? _reply;
    public MultipleChoiceQuestion(string question, Question defaultAnswer, List<Option> options)
    {
        _question = question;
        _defaultAnswer = defaultAnswer;
            
        _options = options;
    }
    public void Be(object reply)
    {
        _reply = (string)reply;
    }
    public Question NextQuestion()
    {
       
        if (_reply == null) return this;
        return Option.NextQuestion(_options, _reply, _defaultAnswer);
    }

    

    string Question.GetQuestionText()
    {
        return _question;
    }

    public object ParseUserInput(string? userInput)
    {
        return userInput;
    }
}