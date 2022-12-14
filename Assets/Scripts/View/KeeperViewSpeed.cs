using TMPro;
using UnityEngine;
namespace Snake
{
    public sealed class KeeperViewSpeed
    {
        private TMP_Text _textUI;
        private IKeeperViewModel _keeperViewModel;
        public KeeperViewSpeed(IKeeperViewModel keeperViewModel)
        {
            _textUI = GameObject.Find("Speed").GetComponent<TextMeshProUGUI>();
            _keeperViewModel = keeperViewModel;
            _keeperViewModel.OnSpeedChange += OnSpeedChange;
            OnSpeedChange(_keeperViewModel.KeeperModel.Speed);
        }
        public void OnSpeedChange(int speed)
        {
            _textUI.text = $"Speed: {speed}";
        }
        ~KeeperViewSpeed()
        {
            _keeperViewModel.OnSpeedChange -= OnSpeedChange;
        }
    }
}