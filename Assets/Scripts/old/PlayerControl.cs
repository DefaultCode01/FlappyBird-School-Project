// #region bibliotecas
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// #endregion bibliotecas

// public class PlayerControl : MonoBehaviour
// {
// #region variaveis
//     // Declaração de variáveis de controle do player:
//     // Rigidbody e Animator para física e animações
//     // Variáveis de estado como noChao, Dead, podePular e contadores de pulo
//     [SerializeField] private AudioSource morte;
//     [SerializeField] private AudioSource inicio;
//     [SerializeField] private AudioSource pulo;
//     [SerializeField] private AudioSource disparo;
//     [SerializeField] private int maxTiros = 4;
//     [SerializeField] private int tirosRestantes;
//     [SerializeField] private Transform firePoint;
//     [SerializeField] private GameObject projetilPrefab;
//     [SerializeField] private float fireCooldawn;
//     [SerializeField] private int PulosRestantes;
//     [SerializeField] float inicialVelocity;
//     [SerializeField] public float speed;
//     [SerializeField] private bool podePular;
//     [SerializeField] private int puloMax;
//     [SerializeField] private float forcaPulo = 10f;
//     [SerializeField] private bool key;
//     private float proximoDisparo;

//     private Rigidbody2D rb;
//     public Animator anim;
//     private float horizontal;
//     private bool noChao;
//     public bool Dead;
    
//     #endregion variaveis



//     // Awake: inicializa referências e valores iniciais
//     private void Awake()
//     {   tirosRestantes = maxTiros;
//     podePular = true;
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//         puloMax =0;
//         inicialVelocity = speed;
//         PulosRestantes = 0; // Começa sem pulos até encostar em objetos "Pulo"
        
//     }

//     // Update: trata input do jogador e animações
//      void Update()
//     { 
//         // Verifica se o player está morto, bloqueando movimentos
//         if (Dead)
//         {
//             speed = 0;
//             anim.SetBool("Dead", Dead);
//             return;
//         }


//         // Captura input horizontal
//         horizontal = Input.GetAxis("Horizontal");

//         // Atualiza animações Idle e Run
//         anim.SetBool("Idle", horizontal == 0);
//         anim.SetBool("Run", horizontal != 0);

//         // Corrida: aumenta velocidade ao pressionar Shift
//         if (Input.GetKeyDown(KeyCode.LeftShift))speed = inicialVelocity * 1.5f;
//         else if (Input.GetKeyUp(KeyCode.LeftShift))speed = inicialVelocity;

//         // Pulo: só permite se houver pulos disponíveis
//         if (Input.GetButtonDown("Jump") && PulosRestantes > 0)
//         {
//             podePular = true;
//             anim.SetBool("Jump", true);
//             pulo.Play();
//         }

//         if(Input.GetButtonDown("Fire1") && Time.time>= proximoDisparo &&  tirosRestantes > 0)
//         {
//             proximoDisparo = Time.time + fireCooldawn;
//             Disparar();
//             disparo.Play();
//             tirosRestantes--;

//         }

//     }


//     // FixedUpdate: aplica física do movimento e do pulo
// #region movimentacao 
//     private void FixedUpdate()
//     {
//         // Movimento horizontal
//         rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

//         // Ajuste de direção do player
//         if (horizontal > 0)
//             transform.localScale = new Vector3(1, 1, 1);
//         else if (horizontal < 0)
//             transform.localScale = new Vector3(-1, 1,1);

//         // Executa pulo se permitido
//         if (podePular )
//         {
//             rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
//             PulosRestantes--;
//             podePular = false;
//         }







//     }
// #endregion movimentacao

        

//     // OnCollisionEnter2D: detecta colisões com objetos
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
        
//         // Colisão com chão
//         if (collision.gameObject.tag == "chao")
//         {
//             noChao = true;       
//             PulosRestantes = puloMax; // Restaura pulos máximos
//             anim.SetBool("Jump", false); // Reseta animação de pulo

//         }


//         if (collision.gameObject.tag=="Armadilha")
//         {   Debug.Log("Colidiu");
//             Dead = true;
//             morte.Play();
//             anim.SetBool("Dead", Dead);
//             Debug.Log("morrendo");
//         }

//         if (collision.gameObject.tag == "Key")
//         {
//             Debug.Log("Colidiu com a chave");
//             key = true;
//             Destroy(collision.gameObject);
//         }

//         if (collision.gameObject.CompareTag("Porta")&&key)
//         {
//             Debug.Log("Abriu a porta!");
//             Destroy(collision.gameObject);
//             SceneManager.LoadScene("Vitoria");
//         }


//     }
//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         // Colisão com objeto que permite pular
//         if (collision.gameObject.CompareTag ("Pulo"))
//         {
//             PulosRestantes++;   // Incrementa pulos disponíveis
//             puloMax++;          // Mantém registro do máximo de pulos
//             podePular = true;   // Permite o pulo
//             Destroy(collision.gameObject); // Remove objeto
//         }

//         if (collision.gameObject.tag == "Municao")
//         {
    
//             Debug.Log("Colidiu com munição");
//             if(tirosRestantes<4) tirosRestantes ++;
//             Destroy(collision.gameObject);
//         }

//     }
//     // OnCollisionExit2D: detecta quando o player sai do chão
//     private void OnCollisionExit2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("chao"))
//         {
//             noChao = false;
//         }
//     }

//     public void Morreu()
//     {
//         Destroy(gameObject, 3f);
//     }
    


//     public void Disparar()
//     {   
//         int facing = transform.localScale.x >=0 ? 1 :-1;
//         // verifa qual e a escala do eixo x do objeto sendo positivo ou negativo;
//         //isso é usado para poder alterar a escala do projetil;

//         Vector3 spawnPos = firePoint ? firePoint.position : transform.position; Quaternion spawnRot = firePoint ? firePoint.rotation : Quaternion.identity;
//         //spawnPos é a posição que meu objeto sera instanciado.
//         // quartenion é usado para fazer a rotação do objeto que sera instanciado na tela dependendo do valor do eixo x.
            
//         GameObject proj = Instantiate(projetilPrefab, spawnPos, spawnRot);
//         //está instanciando o objeto atraves do prefeb usando a posição do spawn e a rotação dele.

//         Vector3 baseScale = projetilPrefab.transform.localScale; proj.transform.localScale = new Vector3(Mathf.Abs(baseScale.x)*facing, baseScale.y, baseScale.z);
//         // Ajusta a escala do projétil mantendo o tamanho original, invertendo no eixo X conforme a direção (facing) positivo ou negativo.
//     }

// }


