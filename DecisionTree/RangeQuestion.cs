


namespace Exercises.DecisionTree
{
    public class RangeQuestion : Question
    {
        private readonly Question _defaultAnswer;
        private readonly List<Range> _ranges;
        private int? _reply;
        private readonly string _question;

        public RangeQuestion(string question, List<Range> ranges)
        {
            _question = question;
            _ranges = ranges;
        }
        public void Be(object reply)
        {
            _reply = (int)reply;
        }

        public Question NextQuestion()
        {
            if (_reply == null) return this;
            return Range.NextQuestion(_defaultAnswer, _ranges, _reply);
        }

        public object ParseUserInput(string? userInput)
        {
            if (int.TryParse(userInput, out int result))
            {
                return result;
            }
            return -1;
        }

        string Question.GetQuestionText()
        {
            return _question;
        }
    }

    public class RangeBuilder
    {
        
        private Question _question;
        private int _min;
        public  readonly List<Range> _ranges= new();

        internal RangeBuilder(Range range, int min)
        {
            _ranges.Add(range);
            _min = min;
            
        }


        public RangeBuilder UpTo(int max)
        {
           
            _ranges.Add(new Range(_question, _min, max));
            return this;
        }

        public RangeBuilder Question(Question question)
        {
            _question=question;
            return this;
        }

        public List<Range> Otherwise(Question question)
        {
            _ranges.Add(new Range(question,_min,Int32.MaxValue));
            return _ranges;
        }
    }
}