using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider master_volume;
    private void Awake()
    {
        if(master_volume != null && PlayerPrefs.HasKey("volume"))
        {
            float setVolume = PlayerPrefs.GetFloat("volume", 1f);

            master_volume.value = setVolume;
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            master_volume.onValueChanged.AddListener(delegate { SetGameVolume(master_volume.value); });
        }
    }

    public void SetGameVolume(float vol)
    {
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("volume", vol);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
