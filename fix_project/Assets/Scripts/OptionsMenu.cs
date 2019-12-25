using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;



public class OptionsMenu : MonoBehaviour
{
    public Toggle fullScreenTog, vsyncTog;
    public ResItem[] resolutions;
    public int selectedResolution;
    public Text resolutionLable;

    // Music Settings

    public AudioMixer theMixer;
    public Slider mastSlider, musicSlider, sfxSlider;
    public Text mastLabel, musicLable ,sfxLable;

    public AudioSource sfxLoop;



    // Start is called before the first frame update
    void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        // search for resoultion in list
        bool foundRes = false;
        for (int i = 0; i < resolutions.Length; i++)
        {
            // loop through all the resoulktions we have to see if any match and then set it
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            // if no resolution is found set the resoultion
            resolutionLable.text = Screen.width.ToString() + " x " + Screen.height.ToString();
            
        }

        if (PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
            mastSlider.value = PlayerPrefs.GetFloat("MasterVol");
            


        }

        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("MusicVol", PlayerPrefs.GetFloat("MusicVol"));
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
            


        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVol");
            


        }

        mastLabel.text = (mastSlider.value + 80).ToString();
        musicLable.text = (musicSlider.value + 80).ToString();
        sfxLable.text = (sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resleft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    public void resright()
    {
        selectedResolution ++;
        if (selectedResolution > resolutions.Length - 1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLable.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }
    public void ApplyGraphics()
    {
        //Apply graphics
    //    Screen.fullScreen = fullScreenTog.isOn;

        //ApplyVsync
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;

        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        // setresolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical,fullScreenTog.isOn);
    }

    public void SetMasterVol()
    {
        // sound works from -80 to 20db therefore add 80 to make it look like 0 to 100 in text
        mastLabel.text = (mastSlider.value + 80).ToString();
        theMixer.SetFloat("MasterVol", mastSlider.value);
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }

    public void SetMusicVol()
    {
        // sound works from -80 to 20db therefore add 80 to make it look like 0 to 100 in text
        musicLable.text = (musicSlider.value + 80).ToString();
        theMixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }

    public void SetsfxVol()
    {
        // sound works from -80 to 20db therefore add 80 to make it look like 0 to 100 in text
        sfxLable.text = (sfxSlider.value + 80).ToString();
        theMixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }

    public void playSFXLoop()
    {
        sfxLoop.Play();
    }

    public void stopSFXLoop()
    {
        sfxLoop.Stop();
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;

}
