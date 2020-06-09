using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public GameObject HUD;
    public GameObject jugador;
    public Slider life;
    public Slider cd;
    public Slider dash;
    public Text arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life.value = jugador.GetComponent<CharacterMovement>().life / jugador.GetComponent<CharacterMovement>().lifeMax;
        cd.value = jugador.GetComponent<CharacterMovement>().counterMagic / jugador.GetComponent<CharacterMovement>().magicCooldown;
        arrow.text = jugador.GetComponent<CharacterMovement>().arrows.ToString();
        dash.value = jugador.GetComponent<CharacterMovement>().counterDash / jugador.GetComponent<CharacterMovement>().dashCooldownTime;
    }
}
