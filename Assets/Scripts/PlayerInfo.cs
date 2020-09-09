using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [HideInInspector]
    public PlayerProfileModel profile;
    // Start is called before the first frame update
    public static PlayerInfo infoInstance;
    private void Awake()
    {
        infoInstance = this;
    }

    public void LoggedIn()
    {
        GetPlayerProfileRequest getProfReq = new GetPlayerProfileRequest
        {
            PlayFabId = UIManager.loginInstance.playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true
            }
        };


        PlayFabClientAPI.GetPlayerProfile(getProfReq,
            result =>
            {
                profile = result.PlayerProfile;
                Debug.Log("Logged in as :" + profile.DisplayName);

            },
            error =>
            {
                Debug.Log(error.ErrorMessage);
            }
          );
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
