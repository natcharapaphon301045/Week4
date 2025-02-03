namespace Week4.Domain
{
    public class BehaviorScore
    {
        public int ScoreID { get; set; }
        public int Score { get; set; }
        public int StudentID { get; set; }
        public required Student Student { get; set; }
    }
}
