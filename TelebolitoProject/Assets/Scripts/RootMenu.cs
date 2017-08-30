using UnityEngine;
using System.Collections;

public interface RootMenu {

    void switchEnableMenuComponents();

    void destroyActiveSubmenu(GameObject activeSubmenu);
}
