﻿

using Exercises.DecisionTree;
using Range = Exercises.DecisionTree.Range;

namespace Exercises.DecisionTree
{
    public class Option
    {
        private readonly Question _question;
        private readonly string _option;
        public Option(Question question, string option)
        {
            _question = question;
            _option = option;
        } 
        public static Question NextQuestion(List<Option> options, string reply, Question defaultAnswer) =>
            options.FirstOrDefault(option => option._option == reply)?._question.NextQuestion() ?? defaultAnswer;
    }
}

namespace ExtensionMethods
{
    public static class OptionExtensions
    {
        public static Option Question(this string option, Question question) => new(question, option);

    }

    public static class QuestionExtensions
    {
        public static BooleanQuestion Boolean(this string option, Question trueQuestion, Question falseQuestion) =>
            new(option, trueQuestion, falseQuestion);

        public static MultipleChoiceQuestion MultiQuestion(this string option, Question defaultAnswer, params Option[] options) => new(option, defaultAnswer, options.ToList());

        public static NumericQuestion Numeric(this string option, Question question) => new(option, question);
        public static RangeQuestion Range(this string option, List<Range> ranges) => new(option, ranges);

        public static RangeBuilder UpTo(this Question question, int max)
        {
            return new RangeBuilder(new Range(question, Int32.MinValue, max),max);
        }

    }
}