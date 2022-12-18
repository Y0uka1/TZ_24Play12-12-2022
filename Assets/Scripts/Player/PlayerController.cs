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
                        if (movable.CubeCollection.GetCollectionSize() > maximalHigh)
                            maximalHigh = movable.CubeCollection.GetCollectionSize();
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
                // }

                view.AddCubesToCollection(maximalHigh);
            }
        }
    }
}