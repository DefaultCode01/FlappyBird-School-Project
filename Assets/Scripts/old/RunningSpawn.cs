using UnityEngine;

public class RunningSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public void ProximoSpawn(float posX, float posY)
    {
        Instantiate(prefab, new Vector3(posX, posY, 0), Quaternion.identity);
    }
}