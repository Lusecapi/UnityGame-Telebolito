using UnityEngine;
using System.Collections;

public class levelMenuUIScript : MonoBehaviour {

    [SerializeField]
    private GameObject worldSelectorPrefab;
    [SerializeField]
    private Sprite spriteAbleLevelButton;
    [SerializeField]
    private Sprite spriteUnableLevelButton;
    private static Sprite ableLevelButtonSprite;
    private static Sprite unableLevelButtonSprite;
    private static int parentWorldIndex;

    #region Getters and Setters

    public static Sprite AbleLevelButtonSprite
    {
        get
        {
            return ableLevelButtonSprite;
        }

        set
        {
            ableLevelButtonSprite = value;
        }
    }

    public static Sprite UnableLevelButtonSprite
    {
        get
        {
            return unableLevelButtonSprite;
        }

        set
        {
            unableLevelButtonSprite = value;
        }
    }

    public static int ParentWorldIndex
    {
        get
        {
            return parentWorldIndex;
        }

        set
        {
            parentWorldIndex = value;
        }
    }

    #endregion

    // Use this for initialization
    void Start () {

        ableLevelButtonSprite = spriteAbleLevelButton;
        unableLevelButtonSprite = spriteUnableLevelButton;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onBackButtonClick()
    {
        Instantiate(worldSelectorPrefab);
        Destroy(gameObject);
    }
}
