using System;
using Cubes;
using Settings;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace General
{
    public class CubeSpawnService : MonoBehaviour
    {
        [SerializeField] private CubeSpawnSettings spawnSettings;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject positiveCubePrefab;
        [SerializeField] private GameObject negativeCubePrefab;
        [SerializeField] private CubeCollection playerCubeCollection;

        private int spawnedSinceLastNegative = 0;

        private float spawnTimer = 1f;

        private void FixedUpdate()
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
                SpawnCube();
        }

        private void SpawnCube()
        {
            spawnTimer = 1f;
            if (spawnedSinceLastNegative < spawnSettings.MinimalNegativeCubeSpawnFrequency)
            {
                SpawnPositive();
                return;
            }

            if (spawnedSinceLastNegative < spawnSettings.MaximalNegativeCubeSpawnFrequency)
            {
                if (CoinToss())
                {
                    SpawnPositive();
                    return;
                }
                SpawnNegative();
                return;
            }

            SpawnNegative();
        }

        private void SpawnPositive()
        {
            var movable = Instantiate(positiveCubePrefab, spawnPosition.position, Quaternion.identity).GetComponent<Movable>();
            movable.CubeType = ECubeType.Positive;
            var cubesAmount = Random.Range(1, spawnSettings.MaximalPositiveCubeCollectionSize + 1);
            movable.CubeCollection.AddCubes(cubesAmount);
            spawnedSinceLastNegative += cubesAmount;
        }

        private void SpawnNegative()
        {
            var movable = Instantiate(negativeCubePrefab, spawnPosition.position, Quaternion.identity).GetComponent<Movable>();
            movable.CubeType = ECubeType.Negative;
            foreach (var collection in movable.NegativeCubeCollection)
            {
                collection.AddCubes(Random.Range(1,playerCubeCollection.GetCollectionSize()+1));
            }

            spawnedSinceLastNegative = 0;
        }

        private bool CoinToss()
        {
            var random = Random.Range(0, 100);
            Debug.Log(random);
            return  random >= 50;
        }
    }
}