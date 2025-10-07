using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Domain.Aggregates.Question.Entities;

public class QuestionItem : Entity
{
    public Guid QuestionId { get; private set; }
    public Question Question { get; private set; }
    public int Order { get; private set; }
    public string Text { get; private set; }

    private QuestionItem(Guid questionId, int order, string text)
    {
        QuestionId = questionId;
        Order = order;
        Text = text;
    }

    public static QuestionItem Create(Guid questionId, int order, string text)
    {
        return new QuestionItem(questionId, order, text);
    }
}