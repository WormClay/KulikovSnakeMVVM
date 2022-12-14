using UnityEngine;
namespace Snake
{
    public sealed class GameService
    {
        private GameSettings _gameSettings;
        private FoodSpawner _foodSpawner;
        private ISnakeViewModel _player;
        private StatusKeeper _statusKeeper;
        private ListExecute _listExecute;
        public GameService(GameSettings gameSettings, ListExecute listExecute) 
        {
            _gameSettings = gameSettings;
            _foodSpawner = new FoodSpawner(_gameSettings);
            _player = CreateSnake();
            _listExecute = listExecute;
            _statusKeeper = new StatusKeeper(_player, _gameSettings, _listExecute);
        }
        public void Start() 
        {
            _listExecute.Add(_player);
            _foodSpawner.Start();
            BuildWall();
        }
        private void BuildWall() 
        {
            var wallPrefab = Resources.Load<WallView>("Wall");
            var wall = Object.Instantiate(wallPrefab, new Vector3(0, _gameSettings.Height / 2, 0), Quaternion.identity);
            wall.Initialize(SubjectType.not_edible, _gameSettings.WallColor);
            wall.transform.localScale = new Vector3(_gameSettings.Width * 2, 1, 1);
            wall = Object.Instantiate(wallPrefab, new Vector3(0, -_gameSettings.Height / 2, 0), Quaternion.identity);
            wall.Initialize(SubjectType.not_edible, _gameSettings.WallColor);
            wall.transform.localScale = new Vector3(_gameSettings.Width * 2, 1, 1);
            wall = Object.Instantiate(wallPrefab, new Vector3(_gameSettings.Width / 2, 0, 0), Quaternion.identity);
            wall.Initialize(SubjectType.not_edible, _gameSettings.WallColor);
            wall.transform.localScale = new Vector3(1, _gameSettings.Height * 2, 1);
            wall = Object.Instantiate(wallPrefab, new Vector3(-_gameSettings.Width / 2, 0, 0), Quaternion.identity);
            wall.Initialize(SubjectType.not_edible, _gameSettings.WallColor);
            wall.transform.localScale = new Vector3(1, _gameSettings.Height * 2, 1);
        }
        private ISnakeViewModel CreateSnake() 
        {
            var snakeView = Object.Instantiate(Resources.Load<SnakeView>("Head"));
            var tailView = Object.Instantiate(Resources.Load<TailView>("Tail"));
            var snakeModel = new SnakeModel(snakeView.transform, tailView.transform, _gameSettings.StartSpeed);
            var snakeViewModel = new SnakeViewModel(snakeModel, _gameSettings);
            snakeView.Initialize(snakeViewModel);
            tailView.Initialize(SubjectType.not_edible);
            return snakeViewModel;
        }
    }
}
