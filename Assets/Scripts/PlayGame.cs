using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayTheGame);
    }
    public void Test()
    {
        SceneManager.LoadScene("GameScene");
    }
   public void PlayTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
