using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes
{
    public class CubeCollection : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private GameObject primalCube;
        private List<GameObject> _cubes = new List<GameObject>();

        //TODO REMOVE AFTER DEBUG
        public Transform Root => root;

        private void Start()
        {
            _cubes.Add(primalCube);
        }

        public void AddCubes(int amount)
        {
            for (int i = 0; i < Math.Abs(amount); i++)
            {
                if (amount > 0)
                {
                    root.localPosition += new Vector3(0, 0.95f, 0);
                    var cube = Instantiate(cubePrefab, root, true);
                    cube.transform.localPosition = new Vector3(0, 0 - 0.95f * _cubes.Count,
                        0);
                    _cubes.Add(cube);
                }
                else //if (amount < 0)
                {
                    if (_cubes.Count <= 0)
                        throw new Exception("[CubeCollection] Can't subtract from empty collection");
                    Destroy(_cubes[_cubes.Count - 1]);
                    root.localPosition -= new Vector3(0, 0.95f, 0);
                    _cubes.RemoveAt(_cubes.Count - 1);
                }
            }
        }

        public int GetCollectionSize()
            => _cubes.Count;


    }
}