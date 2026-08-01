using UnityEngine;
using UnityEngine.SceneManagement;

public class telaControl : MonoBehaviour
{
    // Carrega a cena do jogo
    public void CarregarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }
        // Carrega a cena do menu do jogo
    public void CarregarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Carrega a cena de vitória
    public void CarregarVitoria()
    {
        SceneManager.LoadScene("Vitoria");
    }

    // Carrega a cena de derrota
    public void CarregarDerrota()
    {
        SceneManager.LoadScene("Derrota");
    }
        // Carrega a cena de score
    public void CarregarScore()
    {
        SceneManager.LoadScene("Score");
    }
    public void CarregarCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    // Reinicia a cena atual
    public void ReiniciarCena()
    {
        SceneManager.LoadScene("Jogo");
    }

    // Fecha o jogo
    public void SairJogo()
    {
        Application.Quit();

        // Funciona apenas no Editor da Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
