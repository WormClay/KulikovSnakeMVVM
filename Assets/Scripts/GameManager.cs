using UnityEngine;
namespace Snake
{
    public sealed class GameManager : MonoBehaviour
    {
        private GameSettings _gameSettings;
        private GameService _gameService;
        private ListExecute _listExecute;
        private void Awake()
        {
            _listExecute = new ListExecute();
            _gameSettings = Resources.Load<GameSettings>("MainSettings");
            _gameService = new GameService(_gameSettings, _listExecute);
        }
        private void Start()
        {
            _gameService.Start();
        }

        private void Update()
        {
            foreach (IExecute e in _listExecute.ListObject)
            {
                e.Execute();
            }
        }
    }
}
