using UnityEngine;
using UnityEngine.UI;

public class OptionsUIHandler : MonoBehaviour
{
    [SerializeField] Slider sfxSlider, musicSlider;

    private void Start()
    {
        sfxSlider.onValueChanged.AddListener(
            delegate
            {
                AudioManager.Instance.SetSFXVolume(sfxSlider.value);
            }
        );

        musicSlider.onValueChanged.AddListener(
           delegate
           {
               AudioManager.Instance.SetMusicVolume(musicSlider.value);
           }
       );
    }

    private void OnEnable()
    {
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
    }
}
