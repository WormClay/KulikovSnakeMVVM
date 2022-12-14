using System.Collections.Generic;
using UnityEngine;
namespace Snake
{
    public sealed class SnakeModel: ISnakeModel
    {
        public Transform Head { get; set; }
        public Transform Tail { get; set; }
        public List<Transform> Body { get; set; }
        public float Speed { get; set; }
        public SnakeModel(Transform head, Transform tail, float speed) 
        {
            Head = head;
            Tail = tail;
            Body = new List<Transform>();
            Speed = speed;
        }
    } 
}
