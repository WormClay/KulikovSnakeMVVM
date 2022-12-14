using UnityEngine;
namespace Snake
{
    [CreateAssetMenu(fileName = "NewSettings", menuName = "SO/Settings", order = 51)]
    public sealed class GameSettings : ScriptableObject
    {
        [field: SerializeField] public float CellSize { get; private set; } = 0.5f;
        [field: SerializeField] public int Width { get; private set; } = 7;
        [field: SerializeField] public int Height { get; private set; } = 5;
        [field: SerializeField] public int StartSpeed { get; private set; } = 5;
        [field: SerializeField] public int StepSpeed { get; private set; } = 1;
        [field: SerializeField] public int Step { get; private set; } = 5;
        [field: SerializeField] public int BaseScore { get; private set; } = 10;
        [field: SerializeField] public Color SnakeColor { get; private set; }
        [field: SerializeField] public Color FoodColor { get; private set; }
        [field: SerializeField] public Color WallColor { get; private set; }
    }
}

