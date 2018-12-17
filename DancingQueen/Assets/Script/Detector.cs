using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private GameObject lastGameObject = null;
    [SerializeField] private GameObject textNullPrefab;
    [SerializeField] private GameObject textNicePrefab;
    [SerializeField] private GameObject textCoolPrefab;
    [SerializeField] private GameObject textPerfectPrefab;
    [SerializeField] private GameObject particulePressedPrefab;
    [SerializeField] private LayerMask raycastLayerMask;
    private SpriteRenderer sprite;
    [SerializeField] private Sprite dancingSprite;
    private bool pressed = false;
    private GameObject pressedArrow = null;

    // Use this for initialization
    void Start ()
	{
	    boxCollider2D = GetComponent<BoxCollider2D>();
	    sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown(gameObject.tag))
        {
            SelectDown();
            pressed = true;
        }

        if (Input.GetButtonUp(gameObject.tag))
        {
            pressed = false;
        }

        foreach (var touch in Input.touches)
        {
            if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SelectDown();
                    pressed = true;
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    pressed = false;
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (boxCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                SelectDown();
                pressed = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
        
        if (pressed)
        {
            sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.white;
        }

        Pressed();

        if (GameManager.Instance.ArrowGameObject[gameObject.tag].Count > 0)
        {
            if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < -2 && !pressedArrow)
            {
                GameManager.Instance.AddScore(0);
                Instantiate(textNullPrefab, transform);
                GameManager.Instance.Fail();
                GameManager.Instance.ArrowGameObject[gameObject.tag][0].GetComponent<Arrow>().Tap();
            }
        }
    }

    public void SelectDown()
    {
        if (GameManager.Instance.ArrowGameObject[gameObject.tag].Count > 0)
        {
            if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 0.5)
            {
                GameManager.Instance.AddScore(3);
                Instantiate(textPerfectPrefab, transform);
                GameManager.Instance.Dancer.GetComponentInChildren<SpriteRenderer>().sprite = dancingSprite;
                GameManager.Instance.ComboCount(true);
                if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].GetComponent<Arrow>().LongArrow)
                {
                    pressedArrow = GameManager.Instance.ArrowGameObject[gameObject.tag][0];
                }
            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 1)
            {
                GameManager.Instance.AddScore(2);
                Instantiate(textCoolPrefab, transform);
                if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].GetComponent<Arrow>().LongArrow)
                {
                    pressedArrow = GameManager.Instance.ArrowGameObject[gameObject.tag][0];
                }

            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y < 2)
            {
                GameManager.Instance.AddScore(1);
                Instantiate(textNicePrefab, transform);
                if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].GetComponent<Arrow>().LongArrow)
                {
                    pressedArrow = GameManager.Instance.ArrowGameObject[gameObject.tag][0];
                }

            }
            else if (GameManager.Instance.ArrowGameObject[gameObject.tag][0].transform.position.y - gameObject.transform.position.y >= 2)
            {
                GameManager.Instance.AddScore(0);
                Instantiate(textNullPrefab, transform);
                GameManager.Instance.Fail();

            }
            if (!GameManager.Instance.ArrowGameObject[gameObject.tag][0].GetComponent<Arrow>().LongArrow)
            GameManager.Instance.ArrowGameObject[gameObject.tag][0].GetComponent<Arrow>().Tap();
        }
    }

    public void Pressed()
    {
        if (pressedArrow)
        {
            if ((pressedArrow.GetComponent<BoxCollider2D>().offset.y + pressedArrow.GetComponent<BoxCollider2D>().size.y + pressedArrow.transform.position.y) - gameObject.transform.position.y >= -1)
            {
                if (pressed)
                {
                    pressedArrow.GetComponent<Arrow>().ArrowPressed();
                    GameManager.Instance.AddScore(0.1f);
                    Instantiate(particulePressedPrefab, transform);
                }
                else
                {
                    pressedArrow.GetComponent<Arrow>().Tap();
                    pressedArrow = null;
                }
            }
            else
            {
                pressedArrow.GetComponent<Arrow>().Tap();
                pressedArrow = null;
            }
        }
    }
}
