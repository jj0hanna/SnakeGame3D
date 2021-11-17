using UnityEngine;

namespace SpawnObjects
{
    public class Booster : MonoBehaviour
    {
        public Spawner spawner;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void OnTriggerEnter(Collider other) //funkar om prefab är i hierachy och destroy inte är på
        {
            if (other.CompareTag("Player"))
            {
            
                Debug.Log("HIT");
                Destroy(gameObject);

            }
        

        }
    }
}
