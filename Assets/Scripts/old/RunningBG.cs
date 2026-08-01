using UnityEngine;

public class RunningBG : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limite = -10f;
    [SerializeField] private float distanciaSpawn = 10f;

    private RunningSpawn spawner;

    private void Start()
    {
        spawner = FindAnyObjectByType<RunningSpawn>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= limite)
        {
            float novoX = transform.position.x + distanciaSpawn;

            spawner.ProximoSpawn(novoX, transform.position.y);

            Destroy(gameObject);
        }
    }
}