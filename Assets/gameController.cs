using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class gameController : MonoBehaviour {

    public GameObject polo;
    public GameObject head;
    public SteamVR_PlayArea playArea;

    private void Start()
    {
        StartCoroutine(SpawnPolos());
    }

    IEnumerator SpawnPolos()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            SpawnPolo();
        }
    }

    private void SpawnPolo()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(playArea.vertices[1].x, playArea.vertices[0].x),
                                            head.transform.position.y,
                                            Random.Range(playArea.vertices[1].z, playArea.vertices[2].z));
        Instantiate(polo, spawnPosition, Quaternion.identity);
    }
}
