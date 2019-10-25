using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeManager : MonoBehaviour
{

    // Start is called before the first frame update
    private int puntaje;
    bool activo;
    int activ;
    string SPuntaje;

    public Text Text_puntaje;

    void Start()
    {
        activo = false;
        puntaje = 0;
        activ = 0;
        SPuntaje = "00";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool act()
    {
        return false;
    }

    public void verificarActividad()
    {
        activ++;
        if (activ > 0)
        {
            activo = true;
        }
        
    }

    public void actualizarMarcadorPlayer()
    {        
        ++puntaje;
        SPuntaje = puntaje.ToString();
        if (puntaje < 10)
        {
            Text_puntaje.text = "0"+SPuntaje;
        }
        else
        {
            Text_puntaje.text = SPuntaje;
        }
        
    }
    
}
