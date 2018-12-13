using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{

    [SerializeField] private GameObject arrowCyanPrefab;
    private bool spawnPreCyan;
    [SerializeField] private GameObject arrowPurplePrefab;
    private bool spawnPrePurple;

    [SerializeField] private bool spawnCyan = true;
    [SerializeField] private bool spawnPurple = true;

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
	        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
	        spawnPreCyan = spawnCyan;
	    }
	    if (spawnPurple != spawnPrePurple)
	    {
	        GameObject arrow = Instantiate(arrowPurplePrefab, transform);
	        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
	        spawnPrePurple = spawnPurple;
	    }
    }
}
