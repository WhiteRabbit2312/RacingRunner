using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class PlayerInputMovement : NetworkBehaviour
    {
        [SerializeField] private float _leftPosition;
        [SerializeField] private float _rightPosition;

        private IMovement _input;

        public override void Spawned()
        {
            Runner.GetComponent<NetworkEvents>().OnInput.AddListener(OnInput);
#if UNITY_EDITOR

            _input = new TestInput();

#elif UNITY_ANDROID
        _input = new MainInput();
#endif
        }

        public override void FixedUpdateNetwork()
        {
            _input.Controller();
        }

        private void OnInput(NetworkRunner runner, NetworkInput input)
        {
            var data = new NetworkInputData();

            if (_input.Left())
            {
                data.PlayerPosition = _leftPosition;
            }

            if (_input.Right())
            {
                data.PlayerPosition = _rightPosition;
            }

            input.Set(data);
        }
    }
}
