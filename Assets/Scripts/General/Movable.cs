using System;
using Cubes;
using Settings;
using UnityEngine;

namespace General
{
    public class Movable : MonoBehaviour
    {
        //WIP
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] public ECubeType CubeType;
        [SerializeField] private CubeCollection cubeCollection;

        public CubeCollection CubeCollection => cubeCollection;

        private void FixedUpdate()
        {
            // var localPosition = transform.localPosition;
            // localPosition -= new Vector3(0,0,_gameSettings.BasicSpeed);
            // transform.localPosition = localPosition;
        }
    }
}