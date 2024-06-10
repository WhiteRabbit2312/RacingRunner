using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Chunk : NetworkBehaviour
    {
        [SerializeField] protected LayerMask LayerMask;
        [SerializeField] protected float Radius;
        [SerializeField] protected float ChangeStat;

        protected PlayerInfo MyPlayerInfo;

        private const int ChildIdx = 0;
        public override void FixedUpdateNetwork()
        {
            Debug.LogError("Chunk");
            DetectHit();
        }

        public virtual void Effect(ref float stat)
        {
            stat -= ChangeStat;
        }

        public virtual void DetectHit()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius, LayerMask);

            foreach (Collider hit in hitColliders)
            {
                if (hit.gameObject.TryGetComponent<PlayerInfo>(out PlayerInfo playerInfo))
                {
                    MyPlayerInfo = playerInfo;
                    Debug.LogError("Hit");
                    //Effect(ref playerInput.Speed);

                    //DestroyItem();

                }
            }
        }

        public virtual void DestroyItem()
        {
            Transform netObj = Object.transform.GetChild(ChildIdx);
            Destroy(netObj.gameObject);
        }
    }
}
