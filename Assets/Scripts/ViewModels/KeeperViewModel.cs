using System;
using UnityEngine;
namespace Snake
{
    public sealed class KeeperViewModel : IKeeperViewModel, IExecute
    {
        public IKeeperModel KeeperModel { get; }
        public event Action<int> OnScoreChange;
        public event Action<int> OnSpeedChange;
        public event Action<bool> OnGameOver;
        private GameSettings _settings;
        private ISnakeViewModel _player;
        private bool _isGameOver;
        public KeeperViewModel(IKeeperModel keeperModel, ISnakeViewModel player, GameSettings settings)
        {
            KeeperModel = keeperModel;
            _settings = settings;
            _player = player;
            _player.OnEat += OnEat;
            _player.OnGameOver += OnGameOverPlayer;
            _isGameOver = false;
            OnSpeedChange += _player.OnSpeedChange;
        }
        public void OnGameOverPlayer()
        {
            _isGameOver = true;
            OnGameOver?.Invoke(_isGameOver);
        }
        public void Execute()
        {
            if (_isGameOver)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Restart();
                }
            }
        }
        private void OnEat()
        {
            if (KeeperModel.Step++ >= _settings.Step) 
            {
                KeeperModel.Step = 1;
                KeeperModel.Speed += _settings.StepSpeed;
                OnSpeedChange?.Invoke(KeeperModel.Speed);
            }
            KeeperModel.Score += (_settings.BaseScore * KeeperModel.Speed);
            OnScoreChange?.Invoke(KeeperModel.Score);
        }
        private void Restart() 
        {
            _isGameOver = false;
            KeeperModel.Score = 0;
            KeeperModel.Speed = _settings.StartSpeed;
            KeeperModel.Step = 1;
            _player.Init();
            OnScoreChange?.Invoke(KeeperModel.Score);
            OnSpeedChange?.Invoke(KeeperModel.Speed);
            OnGameOver?.Invoke(_isGameOver);
        }
        ~KeeperViewModel() 
        {
            _player.OnEat -= OnEat;
            _player.OnGameOver -= OnGameOverPlayer;
            OnSpeedChange -= _player.OnSpeedChange;
        }
    }
}
