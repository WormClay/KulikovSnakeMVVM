namespace Snake
{
    public sealed class FoodModel : IFoodModel
    {
        public SubjectType Type { get; set; }
        public FoodModel(SubjectType type)
        {
            Type = type;
        }
    }
}
