using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    public GameObject[] obj;
    private Transform tr;
    public float spawnMin = 1f;
    public float spawnMax = 2f;

    // Use this for initialization
    void Start () {
        Spawn();
	}
	
	void Spawn () {
        tr = GetComponent<Transform>();
        tr.position = new Vector3(tr.position.x, 0, tr.position.z);
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], tr.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}
}
