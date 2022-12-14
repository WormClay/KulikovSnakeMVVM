using TMPro;
using UnityEngine;
namespace Snake
{
    public sealed class KeeperViewScore
    {
        private TMP_Text _textUI;
        private IKeeperViewModel _keeperViewModel;
        public KeeperViewScore(IKeeperViewModel keeperViewModel)
        {
            _textUI = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            _keeperViewModel = keeperViewModel;
            _keeperViewModel.OnScoreChange += OnScoreChange;
            OnScoreChange(_keeperViewModel.KeeperModel.Score);
        }
        public void OnScoreChange(int score)
        {
            _textUI.text = $"Score: {score}";
        }
        ~KeeperViewScore() 
        {
            _keeperViewModel.OnScoreChange -= OnScoreChange;
        }
    }
}
