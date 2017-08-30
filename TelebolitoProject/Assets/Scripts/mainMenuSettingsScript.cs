using UnityEngine;
using System.Collections;

public class mainMenuSettingsScript : MonoBehaviour {

    private RootMenu parentRootMenu;
    private bool isActiveMenu;

    #region Getters and Setters

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

    #endregion

    // Use this for initialization
    void Start () {

        parentRootMenu.switchEnableMenuComponents();
        isActiveMenu = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (isActiveMenu)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                onCloseButtonClick();
            }
        }
	}

    public void onCloseButtonClick()
    {
        parentRootMenu.destroyActiveSubmenu(gameObject);
    }
}
