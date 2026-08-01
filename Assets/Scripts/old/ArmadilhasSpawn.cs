using UnityEngine;

public class ArmadilhasSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] armadilhaPrefab;
    //criando uma lista de armadilhas no inspector;
    [SerializeField] private float spawnIntervalo;
    //tempo entre o spawn de uma armadilha e outra;
    [SerializeField] private Vector3 spawnPos;
    private float timer;

    void Update()
    {
        spawnPos = transform.localScale = new Vector3(18, Random.Range(-1, -3), 0); 

        timer+= Time.deltaTime;

        if (timer >= spawnIntervalo)
        {
            Instantiate(armadilhaPrefab[Random.Range(0, armadilhaPrefab.Length)], spawnPos, Quaternion.identity);
            spawnIntervalo = Random.Range(100,399) / 100;
            timer=0;
        }
    }
}