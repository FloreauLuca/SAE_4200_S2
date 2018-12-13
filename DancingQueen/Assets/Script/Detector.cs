using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    [SerializeField] private int priority;
    private GameObject lastGameObject = null;
    [SerializeField] private GameObject textScorePrefab;

    // Use this for initialization
    void Start ()
	{
	    boxCollider2D = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag(other.tag))
        {
            GameManager.Instance.ArrowPriority[gameObject.tag] = priority;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GameManager.Instance.ArrowPush[gameObject.tag])
        {
            GameManager.Instance.ArrowPush[gameObject.tag] = false;
            Instantiate(textScorePrefab, transform);
            other.GetComponentInChildren<SpriteRenderer>().color = new Color(other.GetComponentInChildren<SpriteRenderer>().color.r, other.GetComponentInChildren<SpriteRenderer>().color.g, other.GetComponentInChildren<SpriteRenderer>().color.b, 0.2f);
        }
    }
}
