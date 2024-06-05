using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public interface IObstacleFactory
    {
        ObstacleMovement CreateObstacle();
    }
}
