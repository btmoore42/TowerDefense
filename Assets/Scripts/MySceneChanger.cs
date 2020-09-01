using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneChanger : MonoBehaviour
{
   // private AssetBundle myAssetBundle;
   // private string[] scenePaths;

    // Start is called before the first frame update
    void Start()
    {
       // myAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath,"myassetBundle"));
       // scenePaths = myAssetBundle.GetAllScenePaths();
       
    }
    private void OnGUI()
    {
        //if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        //{
         //   Debug.Log("Scene2 loading" + scenePaths[0]);
          // SceneManager.LoadScene(scenePaths[1], LoadSceneMode.Single);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
