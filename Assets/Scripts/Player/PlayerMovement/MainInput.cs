using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class MainInput : NetworkBehaviour, IMovement
    {
        private Vector2 _startPos = Vector2.zero;

        private bool _swipeLeft;
        private bool _swipeRight;
        private bool _swipeRegistered;

        public void ResetLeft()
        {
            _swipeLeft = false;
        }

        public void ResetRight()
        {
            _swipeRight = false;
        }

        public bool Left()
        {
            return _swipeLeft;
        }

        public bool Right()
        {
            return _swipeRight;
        }

        void Update()
        {
            Controller();
        }

        public void Controller()
        {
            _swipeLeft = _swipeRight = false;

            if (Time.timeScale == 0f)
                return;

            if (Input.touchCount == 0)
                return;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    _swipeRegistered = false;
                    break;

                case TouchPhase.Moved:
                    if (_swipeRegistered)
                        return;
                    Vector2 deltaSwipe = touch.position - _startPos;
                    if (Mathf.Abs(deltaSwipe.x) > Mathf.Abs(deltaSwipe.y))
                    {
                        _swipeLeft |= deltaSwipe.x < 0;
                        _swipeRight |= deltaSwipe.x > 0;
                    }

                    _swipeRegistered = true;
                    break;

                case TouchPhase.Ended:
                    _swipeRegistered = false;
                    break;

            }

        }

    }
}