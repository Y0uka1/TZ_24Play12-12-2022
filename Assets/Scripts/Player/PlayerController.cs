using System;
using Cubes;
using General;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView view;
        [SerializeField] private Slider slider;
        public static Action OnCubesAmountZeroOrLess;
        private bool isPlaying = true;

        private void Start()
        {
            slider.minValue = -0.36f;
            slider.maxValue = 0.36f;
            view.AddCubesToCollection(1);
            view.SubscribeToCollectionCollision(OnCubeCollectionCollide);
            gameObject.GetComponentInChildren<Rigidbody>().sleepThreshold = 0f;
            OnCubesAmountZeroOrLess += () => { isPlaying = false; };
        }

        private void Update()
        {
            transform.localPosition = new Vector3(slider.value, transform.localPosition.y, transform.localPosition.z);
        }

        private void OnCubeCollectionCollide(Collision collision)
        {
            if (!isPlaying)
                return;
            var maximalHigh = 0;
            if (!collision.collider.TryGetComponent<Movable>(out var movable))
                return;
            switch (movable.CubeType)
            {
                case ECubeType.Negative:
                {
                    foreach (var collection in movable.NegativeCubeCollection)
                    {
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
                    view.PlayStackAnimation();
                    Destroy(movable.gameObject);
                    break;
                }
                default:
                    throw new Exception("[PlayerController] Invalid cube type");
            }

            var cubesAmount = view.AddCubesToCollection(-maximalHigh);
            if (cubesAmount <= 0)
                OnCubesAmountZeroOrLess?.Invoke();
        }
    }
}