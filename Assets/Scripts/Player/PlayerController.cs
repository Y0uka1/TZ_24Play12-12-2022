using System;
using Cubes;
using General;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView view;

        private void Start()
        {
            view.AddCubesToCollection(1);
            view.SubscribeToCollectionCollision(OnCubeCollectionCollide); 
        }

        private void OnCubeCollectionCollide(Collision collision)
        {
            var maximalHigh = 0;
            // foreach (var contact in collision.contacts)
            // {
            if (!collision.collider.TryGetComponent<Movable>(out var movable))
                return;
            switch (movable.CubeType)
            {
                case ECubeType.Negative:
                {
                    foreach (var collection in movable.NegativeCubeCollection)
                    {
                         Debug.Log($"{collection.transform.name} ==== {Vector3.Distance(collection.transform.position, transform.position)}");
                        if (Vector3.Distance(collection.transform.position, transform.position) < 1.2f)
                        {
                            if (collection.GetCollectionSize() > maximalHigh)
                                maximalHigh = collection.GetCollectionSize();
                        }
                    }

                    break;
                }
                case ECubeType.Positive:
                {
                    view.AddCubesToCollection(movable.CubeCollection.GetCollectionSize());
                    Destroy(movable.gameObject);
                    break;
                }
                default:
                    throw new Exception("[PlayerController] Invalid cube type");
            }

            view.AddCubesToCollection(-maximalHigh);
            // }
        }
    }
}