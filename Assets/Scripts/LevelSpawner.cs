using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {
    //levelSegments
    public GameObject cave1;
    public GameObject cave2;
    public GameObject ramp1;
    public GameObject ramp2;
    public GameObject ramp3;

    public GameObject backGroundLava;

    private GameObject player;
    private float spawnLocation;
    private float bGSpawnLocation;

    void Start() {
        player = GameObject.Find("Player");
        spawnLocation = gameObject.transform.position.x;
        bGSpawnLocation = gameObject.transform.position.x;
    }


    void Update() {
        gameObject.transform.position = new Vector3(player.transform.position.x + 75, 0, 0);

        if (gameObject.transform.position.x >= spawnLocation + 50) {
            SpawnSegment();
            spawnLocation = gameObject.transform.position.x;
        }

        if (gameObject.transform.position.x >= bGSpawnLocation + 50) {
            SpawnBackGroundLava();
            bGSpawnLocation = gameObject.transform.position.x;
        }

    }

    private void SpawnSegment() {
        int whatSegment = Random.Range(1, 5 + 1);
        switch (whatSegment) {
            case 1:
                Destroy(Instantiate(cave1, new Vector3(transform.position.x, transform.position.y - 1.35f, transform.position.z), transform.rotation), 20);
                break;
            case 2:
                Destroy(Instantiate(ramp1, new Vector3(transform.position.x, transform.position.y - 1.35f, transform.position.z), transform.rotation), 20);
                break;
            case 3:
                Destroy(Instantiate(ramp2, new Vector3(transform.position.x, transform.position.y - 1.35f, transform.position.z), transform.rotation), 20);
                break;
            case 4:
                Destroy(Instantiate(ramp3, new Vector3(transform.position.x, transform.position.y - 1.35f, transform.position.z), transform.rotation), 20);
                break;
            case 5:
                Destroy(Instantiate(cave2, new Vector3(transform.position.x, transform.position.y - 1.35f, transform.position.z), transform.rotation), 20);
                break;
        }
    }

    private void SpawnBackGroundLava() {
        GameObject lava = Instantiate(backGroundLava, new Vector3(transform.position.x + 100, transform.position.y + Random.Range(-50,50), 95), transform.rotation);
        lava.transform.localScale = new Vector3(Random.Range(10,150), Random.Range(10, 25), 1);

        Destroy(lava, 60);
    }
}
