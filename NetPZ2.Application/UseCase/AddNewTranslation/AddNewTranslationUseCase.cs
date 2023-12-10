using LingvoTry.DB;
using LingvoTry.Models;

namespace NetPZ2.Application.UseCase.AddNewTranslation;

public class AddNewTranslationUseCase
{
    public async Task Execute(List<Translation> translation)
    {
        var db = new EfContext("Data Source=identifier1.sqlite");
        await db.AddToDb(translation);
    }
}

public class GetTranslationUseCase
{
    public async Task<List<Translation>> Execute(List<string> tags, int count)
    {
        tags = tags.Where(x => x != "").ToList();
        var db = new EfContext("Data Source=identifier1.sqlite");
        return await db.GetFromDb(count, tags);
    }
}

public class AnswerTryUseCase
{
    public async Task Execute(List<AnswerTry> answers)
    {
        var db = new EfContext("Data Source=identifier1.sqlite");
        var ids = answers.Select(x => x.TranslationId);
        var translations = await db.GetFromDb(ids);
        foreach (var answer in answers)
        {
            var newRating = answer switch
            {
                { WrongAnswersCount: 0, TooLongAnswersCount: 0 } => 10.0,
                { WrongAnswersCount: 1 } => 6.0,
                { WrongAnswersCount: 2 } => 4.0,
                { WrongAnswersCount: 3 } => 2.0,
                { WrongAnswersCount: >4 } => 0.0,
                { TooLongAnswersCount: 1 } => 9.0,
                { TooLongAnswersCount: 2 or 3 } => 9.0,
                { TooLongAnswersCount: 4 or 5 } => 8.0,
                { TooLongAnswersCount: >5 } => 7.0,
                _ => throw new ArgumentOutOfRangeException()
            };

            var relatedTranslation = translations.FirstOrDefault(x => x.TranslationId == answer.TranslationId);
            var currentRating = relatedTranslation!.Rating;

            var newCof = currentRating > newRating ? 2 : 1;
            var updatedRating = currentRating * (newCof-1.0) / newCof + 
                                newRating * (1.0 / newCof);
            relatedTranslation.Rating = updatedRating;
        }

        await db.AddToDb(translations);
    }
}

