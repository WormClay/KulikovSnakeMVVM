using System;
using UnityEngine;
namespace Snake
{
    public sealed class InputController : IExecute
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private IMove _moveObject;
        private float _horizontal;
        private float _vertical;
        internal InputController(IMove moveObject)
        {
            _moveObject = moveObject;
        }
        public void Execute()
        {
            _horizontal = Input.GetAxis(Horizontal);
            _vertical = Input.GetAxis(Vertical);
            if (Math.Abs(_horizontal) > Math.Abs(_vertical))
            {
                if (_horizontal > 0) { _moveObject.Move(Direction.Right); }
                else if (_horizontal < 0) { _moveObject.Move(Direction.Left); }
            }
            else
            {
                if (_vertical > 0) { _moveObject.Move(Direction.Up); }
                else if (_vertical < 0) { _moveObject.Move(Direction.Down); }
            }
        }
    }
}

