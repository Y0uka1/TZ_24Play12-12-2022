using System;
using Cubes;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject stickMen;
        [SerializeField] private CubeCollection cubeCollection;

        public void AddCubesToCollection(int amount)
        {
            cubeCollection.AddCubes(amount);
        }
        
        public void SubscribeToCollectionCollision(Action<Collision> action) =>
            cubeCollection.GetComponent<CollisionToEvent>().OnCubeCollide += action; //Ugly. Need refactor

        private void FixedUpdate()
        {
            //TODO DELETE
            if (Input.GetKeyDown(KeyCode.E))
                cubeCollection.AddCubes(1);
            if (Input.GetKeyDown(KeyCode.Q))
                cubeCollection.AddCubes(-1);
            if (Input.GetKey(KeyCode.A))
                transform.position -= new Vector3(0.2f, 0, 0);
            if (Input.GetKey(KeyCode.D))
                transform.position += new Vector3(0.2f, 0, 0);
            if (Input.GetKey(KeyCode.W))
                transform.position += new Vector3(0, 0, 0.2f);
            if (Input.GetKey(KeyCode.S))
                transform.position -= new Vector3(0, 0, 0.2f);
        }
    }
}