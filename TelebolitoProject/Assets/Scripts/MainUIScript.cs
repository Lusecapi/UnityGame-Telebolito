using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour, RootMenu {


    private bool isActiveMenu;
    [SerializeField]
    Button[] menuButtons;
    [SerializeField]
    private GameObject mainMenuSettingsMenuPrefab;
    [SerializeField]
    private GameObject worldSelectorMenuPrefab;
	// Use this for initialization
	void Start () {

        isActiveMenu = true;
        if (!SettingsManager.WereDataLoaded)
        {
            SettingsManager.loadSettingsFromFile();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (isActiveMenu)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                onExitButtonClick();
            }
        }
	}

    public void switchEnableMenuComponents()
    {
        isActiveMenu = !isActiveMenu;
        for (int i = 0; i < menuButtons.Length; i++)
        {
            Button b = menuButtons[i];
            b.enabled = !b.enabled;
        }
    }

    public void destroyActiveSubmenu(GameObject activeSubmenu)
    {
        Destroy(activeSubmenu);
        switchEnableMenuComponents();
    }

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene(1);
        //Instantiate(worldSelectorMenuPrefab);
        //Destroy(gameObject);
    }

    public void onExitButtonClick()
    {
        Message.showConfirmationWindow(0, Message.ConfirmationAction.QuitApplication, this);
    }

    public void onSettingsButtonClick()
    {
        GameObject menu = Instantiate(mainMenuSettingsMenuPrefab);
        menu.GetComponent<mainMenuSettingsScript>().ParentRootMenu = this;
    }

    public void onInfoButtonClick()
    {

    }

    public void onFacebookButtonClick()
    {
        OpenFacebookPage();
        //Application.OpenURL("https://www.facebook.com/Blartenix-1774882169417525/");
    }

    void OpenFacebookPage()
    {
        float startTime;
        startTime = Time.timeSinceLevelLoad;

        //open the facebook app
        Application.OpenURL("fb://Blartenix/1774882169417525/");

        if (Time.timeSinceLevelLoad - startTime <= 1f)
        {
            //fail. Open safari.
            Application.OpenURL("https://www.facebook.com/Blartenix-1774882169417525/");
        }
    }

}
