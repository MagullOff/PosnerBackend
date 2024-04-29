namespace PosnerBackend.Model;

public sealed class Attempt
{
    public int? ReactionSpeed { get; set; }
    public bool IsCueValid { get; set; }
    public AttemptResult AttemptResult { get; set; }
}

public enum AttemptResult
{
    Incorrect = 0,
    Correct = 1,
    Timeout = 2,
}