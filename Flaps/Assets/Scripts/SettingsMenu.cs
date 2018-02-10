using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;




public class SettingsMenu : MonoBehaviour {



    //for master audio
    public AudioMixer audioMixer;
    //getting screen resoultion
    Resolution[] resolution;
    //res dropdown
    public Dropdown resDropdown;

    //start
    private void Start()
    {
        resolution = Screen.resolutions;

        resDropdown.ClearOptions();

        //Resolution array to list convertion to app to dropdown list
        List<string> options = new List<string>();

        //current resolution
        int currentResIndex = 0;

        for (int i = 0; i < resolution.Length; i++)
        {
            // (width *  height)  
            string option = resolution[i].width + "x" + resolution[i].height;
            options.Add(option);

            //to make sure the index has the same value as the resolution index
            if(resolution[i].width == Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        //get current resolutions value
        resDropdown.value = currentResIndex;
        //display value
        resDropdown.RefreshShownValue();
    }

    public void Volume(float vol)
    {
        //  Debug.Log(vol);
        audioMixer.SetFloat("Volume", vol);
        
    }

    //graphics
    public void Quality(int graphicIndex)
    {
        QualitySettings.SetQualityLevel(graphicIndex);
    }

    //resolution
    public void Res(int resIndex)
    {
        //set resolution
        Resolution res = resolution[resIndex];
        //Set sscreen resolution to res
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    //settings
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
