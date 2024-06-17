using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public class Garage : MonoBehaviour
    {


        public void ChooseCar(int carIdx)
        {
            PlayerPrefs.SetInt(GameplayConstants.CarTag, carIdx);
        }
    }
}
