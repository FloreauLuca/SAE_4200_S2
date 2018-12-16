using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang.Runtime;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private GameObject lastGameObject = null;
    [SerializeField] private GameObject textNullPrefab;
    [SerializeField] private GameObject textNicePrefab;
    [SerializeField] private GameObject textCoolPrefab;
    [SerializeField] private GameObject textPerfectPrefab;
    [SerializeField] private LayerMask raycastLayerMask;
    private SpriteRenderer sprite;
    [SerializeField] private Sprite dancingSprite;

    // Use this for initialization
    void Start ()
	{
	    boxCollider2D = GetComponent<BoxCollider2D>();
	    sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	    if (Input.GetButtonDown(gameObject.tag))
	    {
	        Select();
            sprite.color = Color.red;
	    }

	    if (Input.GetButtonUp(gameObject.tag))
	    {
	        sprite.color = Color.white;
        }
        foreach (var touch in Input.touches)
	    {
	       if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
	       {
	           if (touch.phase == TouchPhase.Began)
	           {
                  Select();
	               sprite.color = Color.red;
                }
                if (touch.phase == TouchPhase.Ended)
	           {
	               Select();
	               sprite.color = Color.white;
                }
            }
        }
    }

    public void Select()
    {
        if (GameManager.Instance.ArrowGameObject[gameObject.tag].Count > 0)
        {
            Debug.Log(GameManager.Instance.ArrowGameObject[gameObject.tag][0]);
            if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < -1)
            {
                GameManager.Instance.AddScore(0);
                Instantiate(textNullPrefab, transform);
                GameManager.Instance.Fail();
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 0.5)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textPerfectPrefab, transform);
                GameManager.Instance.Dancer.GetComponentInChildren<SpriteRenderer>().sprite = dancingSprite;
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 1)
            {
                GameManager.Instance.AddScore(2);
                Instantiate(textCoolPrefab, transform);
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 2)
            {
                GameManager.Instance.AddScore(1);
                Instantiate(textNicePrefab, transform);
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y >= 2)
            {
                GameManager.Instance.AddScore(0);
                Instantiate(textNullPrefab, transform);
                GameManager.Instance.Fail();
            }

            Destroy(GameManager.Instance.ArrowGameObject[gameObject.tag][0]);
            GameManager.Instance.ArrowGameObject[gameObject.tag].RemoveAt(0);
        }
    }
}
