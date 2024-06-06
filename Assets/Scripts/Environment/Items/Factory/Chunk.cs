using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Chunk : NetworkBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] protected float Radius;
        [SerializeField] protected int ReduseSpeedAmount;

        public override void FixedUpdateNetwork()
        {
            DetectHit();
        }

        public virtual void Effect(ref float stat)
        {
            stat -= ReduseSpeedAmount;
        }

        public virtual void DetectHit()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius, _layerMask);

            foreach (Collider hit in hitColliders)
            {
                if (hit.gameObject.TryGetComponent<PlayerInfo>(out PlayerInfo playerInput))
                {
                    Effect(ref playerInput.Speed);

                }
            }
        }
    }
}
