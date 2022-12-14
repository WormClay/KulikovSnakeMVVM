using UnityEngine;
namespace Snake
{
    public sealed class KeeperViewGameOver
    {
        private GameObject _textUI;
        private IKeeperViewModel _keeperViewModel;
        public KeeperViewGameOver(IKeeperViewModel keeperViewModel)
        {
            _textUI = GameObject.Find("UIGameOver");
            _textUI.SetActive(false);
            _keeperViewModel = keeperViewModel;
            _keeperViewModel.OnGameOver += OnGameOver;
        }
        public void OnGameOver(bool isGameOver) => _textUI.SetActive(isGameOver);
        ~KeeperViewGameOver()
        {
            _keeperViewModel.OnGameOver -= OnGameOver;
        }
    }
}