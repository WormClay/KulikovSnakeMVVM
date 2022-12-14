using UnityEngine;
namespace Snake
{
    public class WallView : MonoBehaviour, ISubject
    {
        public SubjectType Type { get; private set; }
        public void Initialize(SubjectType type, Color color)
        {
            Type = type;
            transform.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
