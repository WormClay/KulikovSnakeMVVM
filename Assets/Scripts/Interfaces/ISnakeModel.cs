using System.Collections.Generic;
using UnityEngine;
namespace Snake
{
    public interface ISnakeModel
    {
        public Transform Head { get; set; }
        public Transform Tail { get; set; }
        public List<Transform> Body { get;}
        public float Speed { get; set; }
    }
}