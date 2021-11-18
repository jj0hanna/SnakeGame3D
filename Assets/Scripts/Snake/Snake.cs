using Game;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using System.Collections;

//using System.Collections.Generic.IEnumerator;

namespace Snake
{
    public class Snake : MonoBehaviour
    {
        public GameManager gameManager;
        
        [SerializeField] private Transform bodyPartPrefab;
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private float addSpeed = 0.01f;
        [SerializeField] private float removeSpeed = 5f;
        [SerializeField] private float timer = 5;
        
        private int boosters = 0;
        private Vector3 newDirection = Vector3.right;
        private Vector3 origPos, targetPos;
        private float maxSpeed = 0.08f;
        private float currentspeed;
        
    
        private SnakeSlinkedlist<SnakeBody> list = new SnakeSlinkedlist<SnakeBody>();
        
        private class SnakeBody
        {
            public Transform transform;
            public Vector3 direction;

            public Vector3 Move(Vector3 newDirection)
            {
                Vector3 Olddirection = direction;
                direction = newDirection;
                transform.position += newDirection;

                return Olddirection;
            }
            public SnakeBody(Transform transform, Vector3 direction)
            {
                this.transform = transform;
                this.direction = direction;
            }
        }
        
        private void Awake()
        {
            list.Add(new SnakeBody(transform, Vector3.zero)); // adding head to list
            StartCoroutine(MovePlayer());
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (newDirection == Vector3.back)
                {
                    newDirection = Vector3.back;
                }
                else if (newDirection!= Vector3.forward)
                {
                    if (newDirection == Vector3.right)
                    {
                        transform.Rotate(0,-90,0); // so the snake rotate to the side its going
                    }
                    else
                    {
                        transform.Rotate(0,90,0);
                    }
                    newDirection = Vector3.forward;
                }
            } 
            if (Input.GetKey(KeyCode.D))
            {
                if (newDirection == Vector3.left)
                {
                    newDirection = Vector3.left;
                    
                }
                else if (newDirection != Vector3.right)
                {
                    if (newDirection == Vector3.forward)
                    {
                        transform.Rotate(0,90,0);
                    }
                    else
                    {
                        transform.Rotate(0,-90,0);
                    }
                    newDirection = Vector3.right;
                }
            } 
            if (Input.GetKey(KeyCode.S))
            {
                if (newDirection == Vector3.forward)
                {
                    newDirection = Vector3.forward;
                }
                else if(newDirection != Vector3.back)
                {
                    if (newDirection == Vector3.right)
                    {
                        transform.Rotate(0,90,0);
                    }
                    else
                    {
                        transform.Rotate(0,-90,0);
                    }
                    newDirection = Vector3.back;
                }
            } 
            if (Input.GetKey(KeyCode.A))
            {
                if (newDirection == Vector3.right)
                {
                    newDirection = Vector3.right;
                }
                else if (newDirection != Vector3.left)
                {
                    if (newDirection == Vector3.forward)
                    {
                        transform.Rotate(0,-90,0);
                    }
                    else
                    {
                        transform.Rotate(0,90,0);
                    }
                    newDirection = Vector3.left;
                }
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Fruit"))
            {
                if (speed >= maxSpeed) // change speed if eat a fruit
                {
                    speed = Mathf.Clamp(speed - addSpeed, maxSpeed, speed);
                }
                
                GameManager.points += 1; // fruit == one more point
                AddBodyPart(); // add bodypart to list if eat fruit
            }
            if (other.CompareTag("Booster"))
            {
                StartCoroutine(SlowSpeed());
            }

            if (other.CompareTag("Wall") || other.CompareTag("BodyPart"))
            {
                gameManager.GetComponent<GameManager>().GameOver();
            }
        }
        private void AddBodyPart()
        {
            Vector3 dirr = list[list.Count - 1].direction;
            Vector3 trans = list[list.Count - 1].transform.position;

            Vector3 newPosition = trans - dirr; // calc new position for new bodypart
            list.Add(new SnakeBody(Instantiate(bodyPartPrefab, newPosition, Quaternion.identity), dirr));
        }
        private IEnumerator MovePlayer()
        {
            while (true)
            {
                Vector3 currentDirection = newDirection;
                Vector3 oldDirection;

                for (int i = 0; i < list.Count; i++, currentDirection = oldDirection )
                {
                    SnakeBody currentNode = list[i];
                    oldDirection = currentNode.Move(currentDirection);
                }
                
                float boostermulti = 1 + (boosters * removeSpeed);
                yield return new WaitForSeconds(speed * boostermulti);
            }
        }
        private IEnumerator SlowSpeed()
        {
            boosters++;
            yield return new WaitForSeconds(timer); // after a time the boost runs out
            boosters--; 
        }
    }
}
