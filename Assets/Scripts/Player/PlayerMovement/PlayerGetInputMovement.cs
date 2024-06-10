using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class PlayerGetInputMovement : NetworkBehaviour
    {
        /*
        public override void FixedUpdateNetwork()
        {
            transform.Translate(Vector3.forward);

            Debug.LogError("Get input bool " + GetInput(out NetworkInputData data1));

            if (GetInput(out NetworkInputData data))
            {
                Debug.LogError("Get input");
                StartCoroutine(ChangePosition(data.PlayerPosition));
            }
        }

        private IEnumerator ChangePosition(float newX = 0)
        {
            Debug.LogError("Change pos");
            float t = 0f;
            Vector3 startPos = transform.position;
            while (transform.position.x != newX)
            {
                t += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(startPos,
                    new Vector3(newX, transform.position.y, transform.position.z), t);
                yield return new WaitForEndOfFrame();
            }

        }*/
    }
}
