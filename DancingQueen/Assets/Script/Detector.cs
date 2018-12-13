using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    // Use this for initialization
    void Start ()
	{
	    boxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	    if (Input.GetButtonDown(gameObject.tag))
	    {
	        Select();
	    }

	    foreach (var touch in Input.touches)
	    {
	        if (touch.phase == TouchPhase.Began)
	        {
	            if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
	            {
                    Select();
	            }
            }
        }
    }

    public void Select()
    {
            if (GameManager.Instance.ArrowGameObject[gameObject.tag].Count > 0)
                Debug.Log(GameManager.Instance.ArrowGameObject[gameObject.tag][0]);
            if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < -1)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textNullPrefab, transform);
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 0.5)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textPerfectPrefab, transform);
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 1)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textCoolPrefab, transform);
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 2)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textNicePrefab, transform);
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y >= 5)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textNullPrefab, transform);
            }
            Destroy(GameManager.Instance.ArrowGameObject[gameObject.tag][0]);
            GameManager.Instance.ArrowGameObject[gameObject.tag].RemoveAt(0);
    }
    
}
