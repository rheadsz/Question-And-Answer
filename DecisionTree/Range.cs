

namespace Exercises.DecisionTree
{
    public class Range
    {
        private readonly Question _question;
        private readonly int _mininmumValue;
        private readonly int _maximumValue;
        private System.Range _range = new System.Range();


        public Range(Question question, int mininmumValue, int maximumValue)
        {
            _question = question;
            _mininmumValue = mininmumValue;
            _maximumValue = maximumValue;
        }

        public static Question NextQuestion(Question defaultAnswer, List<Range> ranges, int? reply) =>
            ranges.FirstOrDefault(range => IsInRange(range, reply))?._question.NextQuestion() ?? defaultAnswer;

        public static bool IsInRange(Range range, int? reply) =>
            (range._mininmumValue <= reply && range._maximumValue >= reply);
    }
}