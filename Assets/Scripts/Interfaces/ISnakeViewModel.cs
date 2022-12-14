using System;
namespace Snake
{
    public interface ISnakeViewModel: IExecute
    {
        public void Ñollision(ISubject subject);
        public event Action OnGameOver;
        public event Action OnEat;
        public void Init();
        public void OnSpeedChange(int speed);
    }
}
