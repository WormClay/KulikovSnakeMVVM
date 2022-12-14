using System;
using UnityEngine;
namespace Snake
{
    public sealed class SnakeViewModel : IExecute, ISnakeViewModel, IMove
    {
        private ISnakeModel _snakeModel;
        public event Action OnGameOver;
        public event Action OnEat;
        private bool _isAte = false;
        private float _timer;
        private const float TIMER_STEP = 1;
        private InputController _inputController;
        private GameSettings _settings;
        private Direction _direction = Direction.Up;
        private Vector3 _directionVector;
        private Vector3 _rotation;
        private bool _isGameOver = false;
        private PoolContainer _bodyPool;
        private const string _prefabName = "Body";
        private const string _rootName = "SnakeBody";
        private const int _startPoolCount = 10;
        public SnakeViewModel(ISnakeModel snakeModel, GameSettings settings)
        {
            _snakeModel = snakeModel;
            _timer = TIMER_STEP;
            _inputController = new InputController(this);
            _settings = settings;
            _directionVector = Vector3.zero;
            _rotation = Vector3.zero;
            _snakeModel.Head.GetComponent<SpriteRenderer>().color = _settings.SnakeColor;
            _snakeModel.Tail.GetComponent<SpriteRenderer>().color = _settings.SnakeColor;
            _bodyPool = new PoolContainer(_prefabName, _rootName, _startPoolCount);
            Init();
        }
        public void Ñollision(ISubject subject)
        {
            switch (subject.Type)
            {
                case SubjectType.edible:
                    _isAte = true;
                    OnEat?.Invoke();
                    break;
                case SubjectType.not_edible:
                    OnGameOver?.Invoke();
                    _isGameOver = true;
                    break;
                default: break;
            }
        }
        public void Execute()
        {
            if (!_isGameOver)
            {
                _timer -= (Time.deltaTime * _snakeModel.Speed);
                if (_timer < 0)
                {
                    if (_isAte)
                    {
                        _isAte = false;
                        AddBody();
                    }
                    else
                    {
                        _snakeModel.Tail.position = _snakeModel.Body[_snakeModel.Body.Count - 1].position;
                    }
                    for (int i = _snakeModel.Body.Count - 1; i > 0; i--)
                    {
                        _snakeModel.Body[i].position = _snakeModel.Body[i - 1].position;
                    }
                    _snakeModel.Head.position += _directionVector;
                    _snakeModel.Head.rotation = Quaternion.Euler(_rotation);
                    _timer = TIMER_STEP;
                }
                _inputController.Execute();
            }
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (_direction != Direction.Up && _direction != Direction.Down)
                    {
                        _direction = direction;
                        _directionVector.Set(0, _settings.CellSize, 0);
                        _rotation.Set(0, 0, 0);
                    }
                    break;
                case Direction.Down:
                    if (_direction != Direction.Down && _direction != Direction.Up)
                    {
                        _direction = direction;
                        _directionVector.Set(0, -_settings.CellSize, 0);
                        _rotation.Set(0, 0, 180);
                    }
                    break;
                case Direction.Left:
                    if (_direction != Direction.Left && _direction != Direction.Right)
                    {
                        _direction = direction;
                        _directionVector.Set(-_settings.CellSize, 0, 0);
                        _rotation.Set(0, 0, 90);
                    }
                    break;
                case Direction.Right:
                    if (_direction != Direction.Right && _direction != Direction.Left)
                    {
                        _direction = direction;
                        _directionVector.Set(_settings.CellSize, 0, 0);
                        _rotation.Set(0, 0, 270);
                    }
                    break;
                default: break;
            }

        }
        public void Init()
        {
            _isGameOver = false;
            for (int i = 1; i < _snakeModel.Body.Count; i++)
            {
                if (_snakeModel.Body[i].TryGetComponent(out PoolObject poolObject)) 
                {
                    poolObject.Recycle();
                }
            }
            _snakeModel.Body.Clear();
            _snakeModel.Body.Add(_snakeModel.Head);
            _snakeModel.Tail.transform.position = new Vector3(-_settings.CellSize, 0, 0);
            _snakeModel.Head.transform.position = Vector3.zero;
            Move(Direction.Right);
        }
        public void OnSpeedChange(int speed)
        {
            _snakeModel.Speed = speed;
        }
        private void AddBody() 
        {
            var body = _bodyPool.Get(_snakeModel.Head.transform);
            if (body.TryGetComponent(out BodyView bodyView)) 
            {
                bodyView.Initialize(SubjectType.not_edible);
                _snakeModel.Body.Add(bodyView.transform);
                bodyView.GetComponent<SpriteRenderer>().color = _settings.SnakeColor; 
            }
        }
    }
}
