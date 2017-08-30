using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class pauseGameMenuScript : MonoBehaviour {

    private RootMenu parentRootMenu;
    [SerializeField]
    private Button[] menuButtons;

    public RootMenu ParentRootMenu
    {
        get
        {
            return parentRootMenu;
        }

        set
        {
            parentRootMenu = value;
        }
    }

    // Use this for initialization
    void Start() {

        parentRootMenu.switchEnableMenuComponents();
    }

    // Update is called once per frame
    void Update() {

    }

    public void onResumeButtonClick()
    {
        parentRootMenu.destroyActiveSubmenu(gameObject);
    }

    public void onRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
