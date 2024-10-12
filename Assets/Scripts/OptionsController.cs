using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Dropdown res_drop;
    [SerializeField] private TMP_Dropdown qua_drop;
    private Resolution[] resolutions;

    #endregion

    private void Start() => InitRes();

    private void InitRes()
    {
        res_drop.ClearOptions();
        List<string> options = new List<string>();

        resolutions = Screen.resolutions;
        int res_index_now = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            #region width
                int width = resolutions[i].width;
                bool width_compare = width == Screen.currentResolution.width;
            #endregion
            
            #region height
            int height = resolutions[i].height;
            bool height_compare = height == Screen.currentResolution.height;
            #endregion      

            RefreshRate refreshRate = resolutions[i].refreshRateRatio;

            string option = $"{width} x {height} ({refreshRate} hz)";

            options.Add(option);

            if (width_compare && height_compare) res_index_now = i;
        }
        res_drop.AddOptions(options);
        res_drop.RefreshShownValue();      
        LoadSettings(res_index_now);       


    }
    public void SetFullscreen(bool isFullscreen) => Screen.fullScreen = isFullscreen;  

    public void SetResolution(int index)            
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int index) => QualitySettings.SetQualityLevel(index);

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualityPrefs", qua_drop.value);
        PlayerPrefs.SetInt("ResPrefs", res_drop.value);
        PlayerPrefs.SetInt("FullscreenPrefs", System.Convert.ToInt32(Screen.fullScreen));
    }

    private void LoadSettings(int index)
    {
        if (PlayerPrefs.HasKey("QualityPrefs")) qua_drop.value = PlayerPrefs.GetInt("QualityPrefs");
        else qua_drop.value = 3;

        if (PlayerPrefs.HasKey("ResPrefs")) res_drop.value = PlayerPrefs.GetInt("ResPrefs");
        else res_drop.value = index;

        if (PlayerPrefs.HasKey("FullscreenPrefs")) Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPrefs"));
        else Screen.fullScreen = true;
    }
}
    

