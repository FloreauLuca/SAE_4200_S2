using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private bool longArrow;
    public bool LongArrow
    {
        get { return longArrow; }
    }

    [SerializeField] private Sprite pressed;
    [SerializeField] private SpriteRenderer longSpriteRenderer;
    public SpriteRenderer LongSpriteRenderer
    {
        get { return longSpriteRenderer; }
        set { longSpriteRenderer = value; }
    }
	// Use this for initialization
	void Start ()
	{
	    rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        GameManager.Instance.ArrowGameObject[gameObject.tag].Remove(gameObject);
    }

    public void Tap()
    {
        GameManager.Instance.ArrowGameObject[gameObject.tag].Remove(gameObject);
        GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        if (longSpriteRenderer)
        longSpriteRenderer.color = new Color(1, 1, 1, 0.2f);
    }

    public void ArrowPressed()
    {
        longSpriteRenderer.sprite = pressed;
        GameManager.Instance.AddScore(1);
    }
}
