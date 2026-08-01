using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    public RectTransform textoCreditos;
    public float velocidade = 50f;
    public float delay = 0f;
    [SerializeField] ControlBtn cena;
    [SerializeField] AudioSource musicaTema;


    void Start()
    {
        if (cena == null)
        {
            cena = FindAnyObjectByType<ControlBtn>();
        }

        StartCoroutine(IniciarCreditos());
    }

    IEnumerator IniciarCreditos()
    {
        musicaTema.Play();
        yield return new WaitForSeconds(delay);

        while (textoCreditos.anchoredPosition.y < 2188) // ajuste esse valor
        {
            textoCreditos.anchoredPosition += Vector2.up * velocidade * Time.deltaTime;
            yield return null;
        }

       
    }
}

