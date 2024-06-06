using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Hatch : NetworkBehaviour, IReduceSpeed
    {
        [SerializeField] private LayerMask _layerMask;
        private float _radius = 10f;
        private readonly int _reduseSpeedAmount = 2;

        public void ReduceSpeed(ref float speed)
        {
            speed -= _reduseSpeedAmount;
        }

        private void DiscardCar(NetworkTransform carTransform)
        {
            //take car transform and discard it
        }

        public override void FixedUpdateNetwork()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);

            foreach (Collider hit in hitColliders)
            {
                if(hit.gameObject.TryGetComponent<PlayerInfo>(out PlayerInfo playerInput))
                {
                    ReduceSpeed(ref playerInput.Speed);

                }
            }
        }
    }
}