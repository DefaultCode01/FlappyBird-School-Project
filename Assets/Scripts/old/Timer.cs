using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour //GameObject para fazer o contador de tempo;
{
    [SerializeField] private TextMeshProUGUI timeText; //variavel do texto na tela;
    float timer; //variavel de contagem do tempo;

    void Update()
    {
        timer += Time.deltaTime; //colocando calculo do tempo no timer;

        //timeText.text = timer.ToString("F2"); //mostra com 2 casas decimais;

        int totalSeconds = Mathf.FloorToInt(timer); //calculo pra saber o tempo;
        int minutes = totalSeconds / 60; //calculo dos minutos no timer;
        int seconds = totalSeconds % 60; //calculo dos segundos no timer;

        timeText.text = $"{minutes:00}:{seconds:00}";
        //definindo forma que o timer terá em tela;
    }
}
