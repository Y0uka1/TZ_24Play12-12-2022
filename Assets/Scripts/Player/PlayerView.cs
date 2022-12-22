using System;
using Cubes;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject stickMen;
        [SerializeField] private CubeCollection cubeCollection;
        [SerializeField] private Animator animator;
        private static readonly int Jump = Animator.StringToHash("Jump");

        public int AddCubesToCollection(int amount)
        {
            return cubeCollection.AddCubes(amount);
        }
        
        public void SubscribeToCollectionCollision(Action<Collision> action) =>
            cubeCollection.GetComponent<CollisionToEvent>().OnCubeCollide += action; //Ugly. Need refactor

        public void PlayStackAnimation()
        {
            animator.SetBool(Jump,true);
        }

       
    }
}