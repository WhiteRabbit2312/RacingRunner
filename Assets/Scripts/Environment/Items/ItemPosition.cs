using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class ItemPosition : NetworkBehaviour
{
    [SerializeField] private ObjectPosition _objectPositions;
    public override void Spawned()
    {
        int posPoint = GeneratePosIdx();
        Vector3 position = new Vector3(_objectPositions.ItemPosition[posPoint], transform.position.y, transform.position.z);
        transform.position = position;
    }

    private int GeneratePosIdx()
    {
        int positionPointIdx = Random.Range(0, _objectPositions.ItemPosition.Length);
        return positionPointIdx;
    }
}
