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
        [SerializeField] private CubeCollection[] negativeCubeCollection;

        public CubeCollection[] NegativeCubeCollection => negativeCubeCollection;

        public CubeCollection CubeCollection => cubeCollection;

        private void FixedUpdate()
        {
            var localPosition = transform.localPosition;
            localPosition -= new Vector3(0,0,_gameSettings.BasicSpeed);
            transform.localPosition = localPosition;
        }
    }
}