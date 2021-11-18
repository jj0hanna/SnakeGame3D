using UnityEngine;

namespace SpawnObjects
{
    public class Booster : MonoBehaviour
    {
        public Spawner spawner;
        [SerializeField] private float rotationSpeed = 50;

        void Start()
        {
        
        }

        void Update()
        {
            transform.Rotate(0,rotationSpeed*Time.deltaTime,0 );
        }
        private void OnTriggerEnter(Collider other) //funkar om prefab är i hierachy och destroy inte är på
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        

        }
    }
}
