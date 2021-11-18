using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Snake
{
    public class SnakeMovment : MonoBehaviour
    {
    
        public Snake snake;
    
        
        private Vector3 origPos, targetPos;
   
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private float addSpeed = 0.01f;
        [SerializeField] private float removeSpeed = 0.1f;
        [SerializeField] private float timer = 5;

        private float maxSpeed = 0.08f;
        private Vector3 newDirection = Vector3.right;
        private float currentspeed;

        private void Awake()
        {
            StartCoroutine(MovePlayer());
        }

        private void Start()
    
        {
       
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                newDirection = Vector3.forward;
            } 
            if (Input.GetKey(KeyCode.D))
            {
                newDirection = Vector3.right;
            } 
            if (Input.GetKey(KeyCode.S))
            {
                newDirection = Vector3.back;
            } 
            if (Input.GetKey(KeyCode.A))
            {
                newDirection = Vector3.left;
            }
        }
        private IEnumerator MovePlayer()
        {
            while (true)
            {
                origPos = transform.position;
                targetPos = origPos + newDirection;
         
                transform.position = targetPos;
                yield return new WaitForSeconds(speed);
            }
        }

        private IEnumerator SlowSpeed()
        {
            currentspeed = speed;
            speed = speed + removeSpeed;
            yield return new WaitForSeconds(timer);
            speed = currentspeed;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Fruit"))
            {
                if (speed > maxSpeed) // change speed if eat a fruit
                {
                    speed = speed - addSpeed;
                }
            }
            if (other.CompareTag("Booster"))
            {
                StartCoroutine(SlowSpeed());
            }
        }
    }
}
