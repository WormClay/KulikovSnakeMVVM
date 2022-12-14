namespace Snake
{
    public sealed class KeeperModel : IKeeperModel
    {
        public int Speed { get; set; }
        public int Score { get; set; }
        public int Step { get; set; }

        public KeeperModel(int speed) 
        {
            Speed = speed;
            Score = 0;
            Step = 1;
        }
    }
}
