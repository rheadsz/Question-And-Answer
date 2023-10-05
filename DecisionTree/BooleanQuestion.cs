namespace Exercises.DecisionTree
{
    public class BooleanQuestion:Question
    {
        public readonly string _question;
        private readonly Question _trueAnswer;
        private readonly Question _falseAnswer;
        private bool? _reply=null;
        public BooleanQuestion(string question,Question trueAnswer, Question falseAnswer)
        {
            _question = question;
            _trueAnswer = trueAnswer;
            _falseAnswer = falseAnswer;
        }
        public void Be(object reply)
        {
           _reply = (bool)reply;
           
        }
        public Question NextQuestion()
        {
            if (_reply == null) return this;
            return (bool)(_reply) ? _trueAnswer.NextQuestion() : _falseAnswer.NextQuestion();
        }

        string Question.GetQuestionText()
        {
            return _question;
        }
        object Question.ParseUserInput(string? userInput)
        {

            if (bool.TryParse(userInput, out bool result))
            {
                return result;
            }
            throw new ArgumentException("Invalid input. Please enter a valid boolean value.");
        }
    }
}
