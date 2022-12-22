using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEngine;

namespace Cubes
{
    public class CubeCollection : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private GameObject primalCube;
        List<GameObject> _cubes = new List<GameObject>();

        //TODO REMOVE AFTER DEBUG
        public Transform Root => root;

        private void Start()
        {
            // if(primalCube!=null)
            //  _cubes.Add(primalCube);
        }

        public int AddCubes(int amount)
        {
            for (int i = 0; i < Math.Abs(amount); i++)
            {
                if (amount > 0)
                {
                    root.localPosition += new Vector3(0, 0.95f, 0);
                    var cube = Instantiate(cubePrefab, root, true);
                    _cubes.Add(cube);
                    cube.transform.localPosition = new Vector3(0, 0 - 0.95f * _cubes.Count,
                        0);
                }
                else
                {
                    if (_cubes.Count <= 0)
                       break;
                    var removedCube = _cubes[_cubes.Count-1];
                    var wPosition = removedCube.transform.position;
                    _cubes.Remove(removedCube);
                    removedCube.transform.SetParent(null);
                    removedCube.transform.position = new Vector3(wPosition.x,wPosition.y+0.95f*i,wPosition.z);
                    StartCoroutine(MoveAndDestroy(removedCube));
                    root.localPosition -= new Vector3(0, 0.95f, 0);
                }
            }

            return _cubes.Count;
        }

        public int GetCollectionSize()
            => _cubes.Count;

        private IEnumerator MoveAndDestroy(GameObject gameObject)
        {
            var timer = 2f;
            while (timer>0)
            {
                gameObject.transform.localPosition-= new Vector3(0,0,0.2f);
                timer -= Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
            Destroy(gameObject);
        }
    }
}