using UnityEngine;
using System.Collections;

public class Message {

    public enum ConfirmationAction
    {
        QuitApplication,
        QuitGame
    }

    private static string[] messagesArray =
    {
        "Are you sure want to leave?"
    };


    public static void showConfirmationWindow(int messageIndex,ConfirmationAction confirmationAction, RootMenu parentRoorMenu)
    {
        new ConfirmationWindow(messagesArray[messageIndex], confirmationAction, parentRoorMenu);
    }

    public static void showConfirmationWindow(string message, ConfirmationAction confirmationAction, RootMenu parentRoorMenu)
    {
        new ConfirmationWindow(message, confirmationAction, parentRoorMenu);
    }


    
    private class ConfirmationWindow
    {
        private GameObject confirmationWindow = Resources.Load("Menus/ConfirmationWindowPrefab") as GameObject;

        public ConfirmationWindow(string theMessage,ConfirmationAction confirmationAction, RootMenu parentRootMenu)
        {
            GameObject window = MonoBehaviour.Instantiate(confirmationWindow);
            confirmationWindowScript windowScript = window.GetComponent<confirmationWindowScript>();
            windowScript.ShowedMessage = theMessage;
            windowScript.ParentRootMenu = parentRootMenu;
            windowScript.ConfirmationAction = confirmationAction;
        }
    }
}
