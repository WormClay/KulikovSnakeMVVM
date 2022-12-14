using UnityEngine;
namespace Snake
{
    public sealed class FoodFactory
    {
        private readonly string _prefabName = "Food";
        private FoodView _prefab;
        private Vector3 _position;
        private GameSettings _settings;
        public FoodFactory(GameSettings settings) 
        {
            _prefab = Resources.Load<FoodView>(_prefabName);
            _position = Vector3.zero;
            _settings = settings;
        }
        public IFoodViewModel Create() 
        {
            var model = new FoodModel(SubjectType.edible);
            var viewModel = new FoodViewModel(model, _settings);
            _position.Set(Random.Range(-(_settings.Width/2)+1, _settings.Width / 2), Random.Range(-(_settings.Height / 2)+1, _settings.Height / 2), 0);
            FoodView view = Object.Instantiate(_prefab, _position, Quaternion.identity);
            view.Initialize(viewModel);
            return viewModel;
        }
    }
}
