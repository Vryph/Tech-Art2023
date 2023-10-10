using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField]public Camera[] cameras;
    [SerializeField] public Light[] lights;
    [SerializeField] public ParticleSystem fire;
    private int selectedCamera = 0;
    private bool boolLights = true;
    private bool boolParticles = true;


    private void Start()
    {
        Debug.Log($"1, 2 e 3 para trocar entre as câmeras, F apaga as luzes e G Muda o estado da fogueira.");
        Debug.Log($"Tem um pequeno bug alguma coisa não estão carregando no início da cena, mas acho que só despausar o jogo ''conserta''.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedCamera = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)){
            selectedCamera = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)){
            selectedCamera = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (boolLights == true)
            {
                boolLights = false;

                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].enabled = false;
                }
            }
            else
            {
                boolLights = true;

                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].enabled = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (boolParticles == true)
            {
                boolParticles = false;
                fire.Stop();
            }
            else
            {
                boolParticles = true;
                fire.Play();
            }
        }
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i != selectedCamera)
            {
                cameras[i].depth = 0;
            }
        }
        cameras[selectedCamera].depth = 1;

    }
}
