using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public interface IObstacleFactory 
    {
        Obstacle CreateObstacle(float obstaclePositionZ);
    }
}
