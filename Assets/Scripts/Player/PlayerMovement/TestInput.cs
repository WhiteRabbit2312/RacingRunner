using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class TestInput : NetworkBehaviour, IMovement
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
                Debug.LogError("Left");
                _toLeft = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.LogError("Right");
                _toRight = true;
            }

            _toLeft = false;
            _toRight = false;
        }
    }
}