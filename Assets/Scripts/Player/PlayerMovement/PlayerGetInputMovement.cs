using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


namespace RacingRunner
{
    public class PlayerGetInputMovement : NetworkBehaviour
    {
        [SerializeField] private float _speed;
        public override void FixedUpdateNetwork()
        {
            if (GetInput(out NetworkInputData data))
            {
                StartCoroutine(ChangePosition(data.PlayerPosition));
            }
        }

        private IEnumerator ChangePosition(float newX = 0)
        {
            float t = 0f;
            Vector3 startPos = transform.position;
            while (transform.position.x != newX)
            {
                t += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(startPos,
                    new Vector3(newX, transform.position.y, transform.position.z), t);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
