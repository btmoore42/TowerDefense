using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{   [HideInInspector]
    public string playFabId;
    // Start is called before the first frame update
    public InputField unameInput;
    public InputField pwordInput;
    public Text displayText;
    public UnityEvent onLogin;


    public void OnLoginButton()
    {
        LoginWithPlayFabRequest lRequest = new LoginWithPlayFabRequest
        {
            Username = unameInput.text,
            Password = pwordInput.text
        };
        PlayFabClientAPI.LoginWithPlayFab(lRequest,
            result =>
             {
                displayText.text = ("Logged in as: " + result.PlayFabId);
                playFabId = result.PlayFabId;
                if(onLogin!=null)
                {
                  onLogin.Invoke();
                }
              },
            error =>
             {
                 Debug.Log(error.ErrorMessage);
                 displayText.text = error.ErrorMessage;
             }
        );
    }

   public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
  
}
