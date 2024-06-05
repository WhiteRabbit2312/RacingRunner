using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Hatch : NetworkBehaviour, IReduceSpeed
    {
        public LayerMask layerMask;
        private float _radius = 10f;

        public void ReduceSpeed()
        {
            
        }

        private void DiscardCar()
        {

        }

        public override void FixedUpdateNetwork()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, layerMask);

            foreach (Collider hit in hitColliders)
            {
                if(hit.gameObject.TryGetComponent<PlayerInfo>(out PlayerInfo playerInput))
                {

                }
            }
        }
    }
}