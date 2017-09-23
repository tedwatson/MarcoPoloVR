﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class gameController : MonoBehaviour {

    public float wallBuffer = .4f;
    public float minPlayerDistance = .5f;
    public GameObject polo;
    public GameObject head;
    public SteamVR_PlayArea playArea;

    private void Start()
    {
        // Make sure our minPlayerDistance isn't set impossibly low
        float maxPossibleSpawnDistance = MaxPossibleSpawnDistance();
        if (minPlayerDistance > maxPossibleSpawnDistance)
        {
            minPlayerDistance = maxPossibleSpawnDistance;
        }

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
        bool foundGoodPosition = false;
        Vector3 spawnPosition = Vector3.zero;
        while (!foundGoodPosition)
        {
            // Pick a random eye-level position within our play area, but not too close to the edges
            spawnPosition = new Vector3(Random.Range(playArea.vertices[1].x + wallBuffer, playArea.vertices[0].x - wallBuffer),
                                                head.transform.position.y,
                                                Random.Range(playArea.vertices[1].z + wallBuffer, playArea.vertices[2].z - wallBuffer));
            // Make sure it's not too close to the player
            if (DistanceIgnoringVertical(spawnPosition, head.transform.position) > minPlayerDistance)
            {
                foundGoodPosition = true;
            }
        }
        Instantiate(polo, spawnPosition, Quaternion.identity);
    }
    

    private float DistanceIgnoringVertical(Vector3 p1, Vector3 p2)
    {
        return Vector3.Distance(new Vector3(p1.x, 0, p1.z), 
                                new Vector3(p2.x, 0, p2.z));
    }

    private float MaxPossibleSpawnDistance()
    {
        // Return the maximum distance polo could spawn, assuming marco is standing in center of play area
        return Vector3.Distance(new Vector3(playArea.vertices[1].x + wallBuffer,
                                            0,
                                            playArea.vertices[1].z + wallBuffer),
                                new Vector3(average(playArea.vertices[1].x, playArea.vertices[0].x),
                                            0,
                                            average(playArea.vertices[1].z, playArea.vertices[2].z)));
    }

    private float average(float a, float b)
    {
        return (a + b) / 2f;
    }
}
