using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Enemy
{
    public class PoolableAsteroidSpawner : MonoBehaviour
    {
        ObjectPool<Asteroid> asteroidPool;
        List<Asteroid> activeAsteroids = new List<Asteroid>();
        Asteroid asteroid;
        Vector3 playerPosition;
        Vector3 randomPosition;
        float releaseRadius = 40f;
        float maxHealth = 100f;
        int randomPrefab;

        [SerializeField] AsteroidFactory asteroidFactory;
        [SerializeField] GameObject[] asteroidPrefabs;
        [SerializeField] Vector3 ignoreSpawnRadius = new Vector3(5f, 0f, 5f);
        [SerializeField] int maxNumOfAsteroids = 20;
        [SerializeField] float spawnRadius = 40f;
        [SerializeField] float spawnInterval = 0.5f;


        void Awake()
        {
            asteroidPool = new ObjectPool<Asteroid>(
                    createFunc: () => (Asteroid)asteroidFactory.SpawnEnemy(asteroidPrefabs[randomPrefab], randomPosition),
                    actionOnRelease: OnReleaseAsteroid,
                    actionOnDestroy: OnDestroyAsteroid,
                    defaultCapacity: maxNumOfAsteroids,
                    maxSize: maxNumOfAsteroids);
        }

        void Start()
        {
            asteroidFactory = new AsteroidFactory();

            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            StartCoroutine(SpawnAsteroids());
        }

        void Update()
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            randomPrefab = GetRandomElement(asteroidPrefabs);

            ReleaseAsteroidWhenTooFarFromPlayer();
        }


        IEnumerator SpawnAsteroids()
        {
            while (true)
            {
                if (asteroidPool.CountActive < maxNumOfAsteroids)
                {

                    randomPosition = ignoreSpawnRadius + Random.insideUnitSphere * spawnRadius;
                    randomPosition.y = 0;

                    asteroid = asteroidPool.Get();
                    asteroid.Initialize(asteroidPool, maxHealth);
                    asteroid.transform.position = playerPosition + randomPosition;
                    asteroid.gameObject.SetActive(true);

                    activeAsteroids.Add(asteroid);

                }
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        void OnReleaseAsteroid(Asteroid asteroid)
        {
            asteroid.gameObject.SetActive(false);
        }

        private void OnDestroyAsteroid(Asteroid asteroid)
        {
            asteroid.Die();

            for (int i = 0; i < activeAsteroids.Count; i++)
            {
                if (asteroid.Equals(activeAsteroids[i]))
                {
                    activeAsteroids.RemoveAt(i);
                }
            }
        }

        private void ReleaseAsteroidWhenTooFarFromPlayer()
        {
            for (int i = 0; i < activeAsteroids.Count; i++)
            {
                Asteroid _asteroid = activeAsteroids[i];
                Vector3 offset = _asteroid.transform.position - playerPosition;
                float sqrLength = offset.sqrMagnitude;

                if (sqrLength > releaseRadius * releaseRadius)
                {
                    activeAsteroids.RemoveAt(i);
                }
            }
        }


        int GetRandomElement(GameObject[] objects) => (int)Random.Range(0, objects.Length);
    }
}
