using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    [SerializeField]
    private Sprite damagedBrickSprite;
    [SerializeField]
    private GameObject starPrefab;
    [SerializeField]
    private float dropProbability;
    private int hitsReceived = 2;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Ball"))
        {
            hitsReceived--;
            if (hitsReceived == 0)
            {
                Destroy(gameObject);
                if (Random.Range(0, 1) <= dropProbability)
                {
                    Instantiate(starPrefab, transform.position, Quaternion.identity);
                }

            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = damagedBrickSprite;
            }
        }
    }
}
