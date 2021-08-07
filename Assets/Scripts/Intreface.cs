using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Audio;

public class Intreface : MonoBehaviour
{
    public GameObject _MainMenu;
    public GameObject _SettingsMenu;

    public InputField _input;
    public Slider _VolSlider;
    public string _PlayerName;
    public AudioMixer _MainMixer;

    public void ShowMainMenu()
    {
        _SettingsMenu.SetActive(false);
        _MainMenu.SetActive(true);
    }

    public void ShowSettingsMenu()
    {
        _SettingsMenu.SetActive(true);
        _MainMenu.SetActive(false);
    }

    public void SetVolume(float val)
    {
        _MainMixer.SetFloat("Volume", val);
        PlayerPrefs.SetFloat("Volume", val);
        PlayerPrefs.Save();
    }

    void Start()
    {
        ShowMainMenu();
    }

    public void GetName()
    {
        _PlayerName = _input.text;
        PlayerPrefs.SetString("PlayerName", _PlayerName);
        PlayerPrefs.Save();
    }

    public void StartGàme()
    {
        _SettingsMenu.SetActive(false);
        _MainMenu.SetActive(false);

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

    }       
}
