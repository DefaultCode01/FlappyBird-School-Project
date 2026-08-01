using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Player : MonoBehaviour
{  
    [SerializeField] private float forcaPulo = 10f;
    [SerializeField] private AudioSource audioMorteSource;
    [SerializeField] private AudioSource audioGameSource;
    //[SerializeField] private int quantidadeParaVencer = 3;
    public static bool GameOver = false;
  
    private Rigidbody2D rb;
    private Animator anim;
    private bool jumping = false;
    private bool morto = false;
    

     void Start()
    {
        GameOver = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private bool morteIniciada = false;

void Update()
{
      if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
    {
        jumping = true;
        anim.SetBool("Pulo", true);
    }

    if (Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1"))
    {
        anim.SetBool("Pulo", false);
    }
 
    
    if (morto == true)
    {
        if (!morteIniciada)
        {
            StartCoroutine(Morrer());
        }
        return;
    }

  
}

IEnumerator Morrer()
{
    morteIniciada = true;

    GetComponent<Rigidbody2D>().gravityScale = 0f;
    anim.SetBool("Morto", true);
    audioMorteSource.Play();

    // Espera o áudio terminar
    yield return new WaitForSeconds(audioMorteSource.clip.length);
    if (morteIniciada == true)
        {
           SceneManager.LoadScene("Derrota");
           GameOver = true;
        }
}
    
    private void FixedUpdate()
    {
        if (jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
            jumping = false;
        }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {  
       
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            morto = true;
            Morrer();
        }
    }

}
 



   