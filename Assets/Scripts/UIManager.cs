using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using TMPro;

public class UIManager : MonoBehaviour
{[HideInInspector]
    public string playFabId;
    // Start is called before the first frame update
    public InputField unameInput;
    public InputField pwordInput;
    public Text displayText;
    public TextMeshProUGUI feedbackText;
    public UnityEvent onLogin;
    public static UIManager loginInstance;

    private void Awake()
    {
        loginInstance = this;
    }
   
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
                 SetFeedbackText("Logged in as: " + result.PlayFabId,Color.green);
                 playFabId = result.PlayFabId;
                 if (onLogin != null)
                 {
                     //   onLogin.Invoke();
                     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                 }
             },
            error =>
             {

                 SetFeedbackText(error.ErrorMessage, Color.red);
             }
        );
    }

    public void RegisterClick()
    { string uname = unameInput.text;
        string pword = pwordInput.text;
        RegisterPlayFabUserRequest regUser;
        regUser = new RegisterPlayFabUserRequest { Username = uname, DisplayName = uname, Password = pword, RequireBothUsernameAndEmail = false };
        PlayFabClientAPI.RegisterPlayFabUser(regUser,
        result => 
        {
            SetFeedbackText(result.PlayFabId, Color.green);
        },
        error =>
        {
            SetFeedbackText(error.ErrorMessage,Color.red);
        }
        );

    }

    void SetFeedbackText(string text, Color color)
    {
        feedbackText.text = text;
        feedbackText.color = color;
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
