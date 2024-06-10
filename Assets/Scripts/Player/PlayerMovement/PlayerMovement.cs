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

        public override void Spawned()
        {
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
            Movement();
        }

        private void Movement()
        {
            transform.Translate(Vector3.forward * _playerInfo.Speed * Time.deltaTime);

            //Debug.LogError("On input");

            if (_input.Right())
            {
                //Debug.LogError("Pressed rights");
                StopAllCoroutines();
                StartCoroutine(ChangePosition(_rightPosition));
            }

            if (_input.Left())
            {
                //Debug.LogError("Pressed left");
                StopAllCoroutines();
                StartCoroutine(ChangePosition(_leftPosition));
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
