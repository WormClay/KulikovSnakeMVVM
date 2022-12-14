using UnityEngine;
namespace Snake
{
    public sealed class TailView : MonoBehaviour, ISubject
    {
        public SubjectType Type { get; private set; }
        public void Initialize(SubjectType type)
        {
            Type = type;
        }
    }
}
