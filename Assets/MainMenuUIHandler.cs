using UnityEngine;

public class MainMenuUIHandler : MonoBehaviour
{
    [SerializeField] GameObject menu, options;
    public void ShowOptions()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
    public void ShowMenu()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }
}
