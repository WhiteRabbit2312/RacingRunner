using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public class TestInput : IMovement
    {
        private bool _toLeft;
        private bool _toRight;

        public bool Left()
        {
            return _toLeft;
        }

        public bool Right()
        {
            return _toRight;
        }

        public void Controller()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _toLeft = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _toRight = true;
            }

            _toLeft = false;
            _toRight = false;
        }
    }
}