using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class playerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler {

    [SerializeField]
    private GameObject bat;
    private bool pointerEnter = false;

    // Use this for initialization
    void Start () {

        bat = GameObject.FindGameObjectWithTag("Bat");
	}
	
	// Update is called once per frame
	void Update () {
        
        if (pointerEnter)
        {
            Vector3 pos = Vector3.zero;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = Mathf.Clamp(pos.x, -2, 2);
            bat.transform.position = Vector3.Lerp(bat.transform.position, new Vector3(pos.x, bat.transform.position.y, 0), 1);
            
        }
	}

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerEnter = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerEnter = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (!LevelManager.GameStarted)
        {
            Debug.Log("pointerup");
            LevelManager.GameStarted = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (LevelManager.IsPaused)
        {
            Time.timeScale = 1;
        }
    }
}
