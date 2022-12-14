using System;
using UnityEngine;
namespace Snake
{
    public sealed class FoodViewModel : IFoodViewModel
    {
        public IFoodModel FoodModel { get; private set; }
        public event Action<IFoodViewModel> FoodEaten;
        public GameSettings Settings { get; }
        public FoodViewModel(IFoodModel foodModel, GameSettings settings) 
        {
            FoodModel = foodModel;
            Settings = settings;
        }
        public void SelfDestroy()
        {
            FoodModel = null;
            FoodEaten?.Invoke(this);
        }
    }
}
