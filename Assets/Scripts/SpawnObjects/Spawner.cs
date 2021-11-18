using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpawnObjects
{
    public class Spawner : MonoBehaviour
    {
        public Transform[] boosters;
        public Transform[] obstacles;
    
        public GameObject fruitPrefab;
        
    

        [SerializeField] private float spawnInterval = 1; 
        [SerializeField] private float spawnIntervalboosters = 10;
        [SerializeField] private float spawnIntervalobstacles = 1;
        [SerializeField] private float spawnBoosterFirstTime = 1;
    
        
        private Vector3 spawnPosition;
    
        void Awake()
        {
            //_camera = Camera.main;
        }

        private void Start()
        {
            StartCoroutine(SpawnFruit());
            StartCoroutine(SpawnBoosters());
        }

        private void Update()
        {
        
        }

        public IEnumerator SpawnBoosters()
        {
            yield return new WaitForSeconds(spawnBoosterFirstTime);// wait this time before start spawning
            while (true)
            {
                spawnPosition = new Vector3(Random.Range(18f, -18f), Random.Range(3f, 3f), Random.Range(18f,-18f));
            
                Transform booster = boosters[Random.Range(0, boosters.Length)];
                Instantiate(booster, new Vector3(Mathf.Round(spawnPosition.x), Mathf.Round(spawnPosition.y), Mathf.Round(spawnPosition.z)), Quaternion.identity);
        
                yield return new WaitForSeconds(spawnIntervalboosters);
            }
        }
        IEnumerator Spawnobsstacles()
        {
            yield return new WaitForSeconds(spawnIntervalobstacles);
        }

        public IEnumerator SpawnFruit()
        {
            spawnPosition = new Vector3(Random.Range(18f, -18f), Random.Range(3f, 3f), Random.Range(18f,-18f));
            Instantiate(fruitPrefab, new Vector3(Mathf.Round(spawnPosition.x), Mathf.Round(spawnPosition.y), Mathf.Round(spawnPosition.z)), Quaternion.identity);//mathf.round so they spawn on grids
            yield return new WaitForSeconds(spawnInterval);
       
        }
    }
}


