using System;
namespace Snake
{
    public interface IFoodViewModel
    {
        public void SelfDestroy();
        public IFoodModel FoodModel { get;}
        public event Action<IFoodViewModel> FoodEaten;
        public GameSettings Settings { get; }
    }
}
