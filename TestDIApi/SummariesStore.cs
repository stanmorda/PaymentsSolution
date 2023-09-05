namespace TestDIApi;

public class SummariesStore
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public SummariesStore()
    {
        // ctor
    }

    public string GetSummaryByIndex(int index)
    {
        return Summaries[index];
    }

    public int GetSummariesCount()
    {
        return Summaries.Length;
    }
}