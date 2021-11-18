using System.IO.MemoryMappedFiles;
using UnityEngine;

namespace Game
{
    public class MapGenerator : MonoBehaviour
    {
        
       [SerializeField] private GameObject prefabwall;
       [SerializeField] private GameObject prefabGround;

       
        void Start()
        {
            TextAsset mapfile = (TextAsset)Resources.Load("map", typeof(TextAsset));
            string s = mapfile.text;

            
            string[] sArr = s.Split('\n');


            for (int i = 0; i < sArr.Length; i++)
            {
                string[] sArr2 = sArr[i].Split('|');
                if (sArr2[0] == "W")
                {
                    string[] pos = sArr2[1].Split(',');
                    string[] scale = sArr2[2].Split(',');
                    
                    
                    GameObject tr = Instantiate(prefabwall, new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])), Quaternion.identity);
                    tr.transform.localScale = new Vector3(float.Parse(scale[0]), float.Parse(scale[1]), float.Parse(scale[2]));
                }
                else if (sArr2[0] == "F")
                {
                    string[] pos = sArr2[1].Split(',');
                    string[] scale = sArr2[2].Split(',');
                

                    GameObject tr = Instantiate(prefabGround, new Vector3(float.Parse(pos[0]), float.Parse(pos[1]), float.Parse(pos[2])), Quaternion.identity);
                    tr.transform.localScale = new Vector3(float.Parse(scale[0]), float.Parse(scale[1]), float.Parse(scale[2]));
                }
                
            }
            ////////////////////////////////////////////////////////////////////////
            // saving for my self ,A other way to loop through if the txt file would look different
            /////////////////////////////////////////////////////////////////////////
        //  for (int i = 0; i < sArr.Length; i++)
        //  {
        //      for (int j = 0; j < sArr[i].Length; j++)
        //      {
        //          if (sArr[i][j] == 'x')
        //          {
        //             GameObject tr = Instantiate(wall, new Vector3(i, 0, j), Quaternion.identity);
        //             tr.transform.localScale = new Vector3(40, 2, 1);
        //          }
        //      }
        //  }
            
        }
    }
}
