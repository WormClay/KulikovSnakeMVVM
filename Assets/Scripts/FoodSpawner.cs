using UnityEngine;
namespace Snake
{
    public sealed class FoodSpawner
    {
        private FoodFactory _foodFactory;
        public FoodSpawner(GameSettings settings)
        {
            _foodFactory = new FoodFactory(settings);
        }
        public void Start()
        {
            Spawn();
            Spawn();
            Spawn();
            /*Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();
            Spawn();*/
        }
        public void OnFoodEat(IFoodViewModel viewModel) 
        {
            viewModel.FoodEaten -= OnFoodEat;
            viewModel = null;
            Spawn();
        }
        private void Spawn() 
        {
            var food = _foodFactory.Create();
            food.FoodEaten += OnFoodEat;
        }
    } 
}
