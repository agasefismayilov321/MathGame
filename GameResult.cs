namespace MathGame;

public class GameResult
{
    public int score { get; set; }
    public int totalQuestion { get; set; }
    public string? operation { get; set; }
    public DateTime gameTime { get; set; }
    public double timeSpent { get; set; }
}