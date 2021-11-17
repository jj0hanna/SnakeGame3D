using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameOverController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void RestartGame()
        {
        
            SceneManager.LoadScene("SampleScene");
        }
    }
}
