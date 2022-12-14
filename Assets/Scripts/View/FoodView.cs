using UnityEngine;
namespace Snake
{
    public sealed class FoodView : MonoBehaviour, ISubject
    {
        private IFoodViewModel _foodViewModel;
        public SubjectType Type { get; private set; }
        public void Initialize(IFoodViewModel foodViewModel)
        {
            _foodViewModel = foodViewModel;
            Type = _foodViewModel.FoodModel.Type;
            GetComponent<SpriteRenderer>().color = _foodViewModel.Settings.FoodColor;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            _foodViewModel?.SelfDestroy();
            Destroy(gameObject);
        }
    }
}
