using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;

        public Text uiPoints;
    
        public static int points;
    
        public Snake.Snake snake;
    
    
        void Start()
        {
            gameOverPanel.SetActive(false);
            
            points = 0;
            Time.timeScale = 1;
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void GameOver()
        {
            Debug.Log("GameOver");
        
            gameOverPanel.SetActive(true);
            uiPoints.text = " Score:" + points.ToString();
        
            Time.timeScale = 0;
        }

    }
}
