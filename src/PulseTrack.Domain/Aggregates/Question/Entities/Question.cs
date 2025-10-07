using PulseTrack.Domain.Aggregates.Question.Enums;
using PulseTrack.Domain.SeedWorks;

namespace PulseTrack.Domain.Aggregates.Question.Entities;

public class Question : Entity
{
    public Guid SurveyId { get; private set; }
    public string Text { get; private set; }
    public QuestionType Type { get; private set; }
    public int Order { get; private set; }
    private List<QuestionItem> _items = [];
    public IReadOnlyCollection<QuestionItem> Items => _items;

    private Question(Guid surveyId, string text, QuestionType type, int order)
    {
        SurveyId = surveyId;
        Text = text;
        Type = type;
        Order = order;
    }

    public static Question Create(Guid surveyId, string text, QuestionType type, int order)
    {
        return new Question(surveyId, text, type, order);
    }

    public void AddItem(int order, string text)
    {
        _items.Add(QuestionItem.Create(Id, order, text));
    }
}