// GameObject para spawnar o chão

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningChaoSpawner : MonoBehaviour
{

    [SerializeField] private GameObject chaoPrefab;
    [SerializeField] private Vector3 spawnPos = new Vector3(18f, -3.5f, 0f);

    public void SpawnNext()
    {
        Instantiate(chaoPrefab, spawnPos, Quaternion.identity);
    }


}
