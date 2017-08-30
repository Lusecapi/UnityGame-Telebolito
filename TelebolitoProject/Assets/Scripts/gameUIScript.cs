using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class gameUIScript : MonoBehaviour, RootMenu {

    [SerializeField]
    private GameObject pauseMenuPrefab;
    [SerializeField]
    Button[] menuButtons;

    private bool isActiveMenu;
    // Use this for initialization
    void Start() {

        isActiveMenu = true;
    }

    // Update is called once per frame
    void Update() {

        if (isActiveMenu)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                onPauseButtonClick();
            }
        }
    }

    public void onPauseButtonClick()
    {
        LevelManager.IsPaused = true;
        GameObject menu = Instantiate(pauseMenuPrefab);
        menu.GetComponent<pauseGameMenuScript>().ParentRootMenu = this;
        Time.timeScale = 0;
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
}
