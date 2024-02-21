using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI vidasTXT;
    public TextMeshProUGUI puntuacionTXT;
    public TextMeshProUGUI tiempoTXT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVidasTXT(int vidas)
    {
        vidasTXT.text="Vidas: " + vidas;
    }

    public void setPuntuacionTXT(int puntuacion)
    {
        puntuacionTXT.text = "Puntuacion: " + puntuacion;
    }

    public void setTiempoTXT(int tiempo)
    {
        int segundos = tiempo%60;
        int minutos = tiempo / 60;
        tiempoTXT.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
}
