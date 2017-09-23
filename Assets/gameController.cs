using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class gameController : MonoBehaviour {

    public float wallBuffer = 2f;
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
            yield return new WaitForSeconds(.1f);
            SpawnPolo();
        }
    }

    private void SpawnPolo()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(playArea.vertices[1].x + wallBuffer, playArea.vertices[0].x - wallBuffer),
                                            head.transform.position.y,
                                            Random.Range(playArea.vertices[1].z + wallBuffer, playArea.vertices[2].z - wallBuffer));
        Instantiate(polo, spawnPosition, Quaternion.identity);
    }
}
