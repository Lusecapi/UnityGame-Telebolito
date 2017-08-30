using UnityEngine;
using System.Collections;

public class confirmationWindowScript : MonoBehaviour {

    private RootMenu parentRootMenu;
    private string showedMessage;
    private Message.ConfirmationAction confirmationAction;

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

    public string ShowedMessage
    {
        get
        {
            return showedMessage;
        }

        set
        {
            showedMessage = value;
        }
    }

    public Message.ConfirmationAction ConfirmationAction
    {
        get
        {
            return confirmationAction;
        }

        set
        {
            confirmationAction = value;
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
                onNoButtonClick();
            }
        }
	}

    public void onNoButtonClick()
    {
        parentRootMenu.destroyActiveSubmenu(gameObject);
    }

    public void onYesButtonClick()
    {
        if (confirmationAction.Equals(Message.ConfirmationAction.QuitApplication))
        {
            Application.Quit();
        }
    }
}
