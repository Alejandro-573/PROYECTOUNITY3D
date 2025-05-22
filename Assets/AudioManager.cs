using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    [SerializeField] float musicVolume, sfxVolume;

    public static AudioManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadMusicVolume();
        LoadSFXVolume();
    }

    private void Start()
    {
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }
    public void SetMusicVolume(float newVolume)
    {
        musicVolume = Mathf.Clamp(newVolume, 0.0001f, 1);
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSFXVolume(float newVolume)
    {
        sfxVolume = Mathf.Clamp(newVolume, 0.0001f, 1);
        mixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadSFXVolume()
    {
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    public void LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }
}
