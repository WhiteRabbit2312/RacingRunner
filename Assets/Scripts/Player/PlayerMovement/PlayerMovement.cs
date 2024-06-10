using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float _leftPosition;
        [SerializeField] private float _centerPosition;
        [SerializeField] private float _rightPosition;
        [SerializeField] private float _speedCoordX;

        private PlayerInfo _playerInfo;

        private IMovement _input;
        private PlayerPosition _playerPosition;

        public override void Spawned()
        {
            _playerPosition = PlayerPosition.Center;
            _playerInfo = GetComponent<PlayerInfo>();

#if UNITY_EDITOR

            _input = new TestInput();

#elif UNITY_ANDROID
        _input = new MainInput();
#endif
        }

        private void Update()
        {
            _input.Controller();
        }

        public override void FixedUpdateNetwork()
        {
            Movement();
        }

        private void Movement()
        {
            transform.Translate(Vector3.forward * _playerInfo.Speed * Runner.DeltaTime);

            //Debug.LogError("On input");

            if (_input.Right())
            {
                //Debug.LogError("Pressed rights");
                StopAllCoroutines();
                if (_playerPosition == PlayerPosition.Center)
                {
                    StartCoroutine(ChangePosition(_rightPosition));
                    _playerPosition = PlayerPosition.Right;
                }

                else if (_playerPosition == PlayerPosition.Left)
                {
                    StartCoroutine(ChangePosition(_centerPosition));
                    _playerPosition = PlayerPosition.Center;
                }
            }

            if (_input.Left())
            {
                //Debug.LogError("Pressed left");
                StopAllCoroutines();

                if(_playerPosition == PlayerPosition.Center)
                {
                    StartCoroutine(ChangePosition(_leftPosition));
                    _playerPosition = PlayerPosition.Left;
                }

                else if (_playerPosition == PlayerPosition.Right)
                {
                    StartCoroutine(ChangePosition(_centerPosition));
                    _playerPosition = PlayerPosition.Center;
                }
                
            }

        }

        private IEnumerator ChangePosition(float newX = 0)
        {
            //Debug.LogError("Change pos");
            float t = 0f;
            Vector3 startPos = transform.position;
            while (transform.position.x != newX)
            {
                t += Time.deltaTime * _speedCoordX;
                transform.position = Vector3.Lerp(startPos,
                    new Vector3(newX, transform.position.y, transform.position.z), t);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
