using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform target;                 // O objeto que a câmera segue (o jogador, por exemplo)
    public float rotationSpeed = 1.0f;       // Velocidade de rotação da câmera
    public float distance = 3.0f;           // Distância da câmera ao alvo
    public Vector3 offset = new Vector3(-25, 49, -84); // Posição relativa da câmera ao alvo

    private void Update()
    {
        if (!Personagem.dialogue)
        {


            // Rotação da câmera
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.RotateAround(target.position, Vector3.up, horizontalInput * rotationSpeed);

            // Atualização da posição da câmera
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);

            // Mantém a câmera olhando para o alvo
            transform.LookAt(target.position);

            // Controle do cursor aqui
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
