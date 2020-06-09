using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseScene();
    }

    public void MainMenuScene() //cargar menu ppal
    {

        SceneManager.LoadScene("MainMenu");

    }

    public void SettingScene() //cargar menu de opciones
    {

        SceneManager.LoadScene("SettingsMenu");

    }

    public void PlayScene () //cargar escena de juego al principio
    {

        SceneManager.LoadScene("SampleScene");

    }


    public void ReturnScene() //reanudar el juego
    {

        SceneManager.LoadScene("MainMenu");

    }



    public void Exitgame() //salir del juego 
    {

        Application.Quit();

    }


    public void PauseScene () //cambiar tecla para abrir menu de pausa
    {

        if (Input.GetKeyDown(KeyCode.Slash)) {


            SceneManager.LoadScene("PauseMenu");


        }


    }




}
