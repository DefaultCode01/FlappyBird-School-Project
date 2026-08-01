//Prefab do Chão

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float leftLimitX = -18f;

    [SerializeField] private RunningChaoSpawner spawner;

    private void Awake()
    {
        if (spawner == null) spawner = FindAnyObjectByType<RunningChaoSpawner>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= leftLimitX)
        {
            spawner.SpawnNext();
            Destroy(gameObject);
        }
        
    }

}
