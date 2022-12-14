using UnityEngine;
namespace Snake
{
    public sealed class BodyView : MonoBehaviour, ISubject
    {
        public SubjectType Type { get; private set; }
        public void Initialize(SubjectType type) 
        {
            Type = type;
        }
    }
}
