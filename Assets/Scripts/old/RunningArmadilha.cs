using UnityEngine;

public class RunningArmadilha : MonoBehaviour
{
  [SerializeField] private float speed;
  //velocidade que a armadilha vai;
  [SerializeField] private float limite;
    //limite q a armadilha irá até ser deletada;

    void Start()
    {
        speed = Random.Range(2,4);
        //a velocidade do obstaculo vai ser aleatorio;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        //velocidade e direção que o BG se mexe;

        if (transform.position.x <= limite) //se a armadilha passar do limite...
        {
            Destroy(gameObject); //...destruir a armadlha.
        }
    }
}
