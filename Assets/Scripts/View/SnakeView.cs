using UnityEngine;
namespace Snake
{
    public sealed class SnakeView : MonoBehaviour
    {
        private ISnakeViewModel _snakeViewModel;
        public void Initialize(ISnakeViewModel snakeViewModel)
        {
            _snakeViewModel = snakeViewModel;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out ISubject subject))
            {
                _snakeViewModel?.Ñollision(subject);
            }
        }

    }
}
