using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // necessário para trocar de cena

public class ControlBtn : MonoBehaviour
{
    // carregar cena do jogo (botão INICIO)
    public void IrParaJogo()
    {
        SceneManager.LoadScene("Game");
    }

    // voltar para menu (caso precise)
    public void IrParaMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void Derrota()
     {
        SceneManager.LoadScene("Perdeu"); // troca de cena
     }
     public void Vitoria()
     {
        SceneManager.LoadScene("Vitoria"); // troca de cena
     }

    // botão sair do jogo
    public void SairDoJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }

    // botão créditos
    public void IrParaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
     public void Player()
    {
        SceneManager.LoadScene("Player");
    }

    public void Personagem_M()
    {
        PlayerPrefs.SetInt("personagem", 0); // masculino
        SceneManager.LoadScene("Game");
    }
    public void Personagem_F()
    {
        PlayerPrefs.SetInt("personagem", 1); // feminino
        SceneManager.LoadScene("Game");
    }



}