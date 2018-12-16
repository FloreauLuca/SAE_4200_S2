using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    [SerializeField] private GameObject arrowCyanPrefab;
    private bool spawnPreCyan;
    [SerializeField] private GameObject arrowPurplePrefab;
    private bool spawnPrePurple;
    [SerializeField] private GameObject arrowLongPrefab;
    private bool spawnPreLong;

    [SerializeField] private bool spawnCyan = true;
    [SerializeField] private bool spawnPurple = true;
    [SerializeField] private bool spawnLong = false;
    private GameObject arrowLong;

    private float longTime;
	// Use this for initialization
	void Start ()
	{
	    spawnPreCyan = spawnCyan;
	    spawnPrePurple = spawnPurple;
	}
	
	// Update is called once per frame
	void Update () {
	    if (spawnCyan != spawnPreCyan)
	    {
	        GameObject arrow = Instantiate(arrowCyanPrefab, transform);
	        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
	        GameManager.Instance.ArrowGameObject[gameObject.tag].Add(arrow);
	        spawnPreCyan = spawnCyan;
	    }
	    if (spawnPurple != spawnPrePurple)
	    {
	        GameObject arrow = Instantiate(arrowPurplePrefab, transform);
	        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
	        GameManager.Instance.ArrowGameObject[gameObject.tag].Add(arrow);
            spawnPrePurple = spawnPurple;
	    }

	    if (!spawnPreLong && spawnLong)
	    {
	        arrowLong = Instantiate(arrowLongPrefab, transform);
	        arrowLong.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
	        GameManager.Instance.ArrowGameObject[gameObject.tag].Add(arrowLong);
	    }
	    else if (spawnPreLong && spawnLong)
	    {
	        arrowLong.GetComponent<Arrow>().LongSpriteRenderer.size = new Vector2(arrowLong.GetComponent<Arrow>().LongSpriteRenderer.size.x, arrowLong.GetComponent<Arrow>().LongSpriteRenderer.size.y + Time.deltaTime);
        }
	    else if (spawnPreLong && !spawnLong)
	    {
	        arrowLong = null;
	    }

	    spawnPreLong = spawnLong;
    }
}
