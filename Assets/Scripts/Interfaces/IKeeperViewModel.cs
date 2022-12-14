using System;
namespace Snake
{
    public interface IKeeperViewModel
    {
        public IKeeperModel KeeperModel { get; }
        public event Action<int> OnScoreChange;
        public event Action<int> OnSpeedChange;
        public event Action<bool> OnGameOver;
    }
}