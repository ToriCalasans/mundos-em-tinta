using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    private Animator animator;

    public float speed = 150.0f;
    public int maxJumps = 1;
    private int jumpCount = 0;
    public float rotationSpeed = 10.0f; // Velocidade de rotação
    public float jumpForce = 15.0f; // Força do pulo
    private Rigidbody rb;

    static public bool dialogue = false;

    void Start()
    {
        // Obtém a referência ao componente Rigidbody
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();



    }
    void Update()
    {
        if (!dialogue)
        {
            Movimento();
        }

        // if (!PlayerMovement.dialogue)
        // {
        //     Cursor.lockState = CursorLockMode.Locked;
        //     Cursor.visible = false;
        //     MyInput();
        //     cameraMove.transform.localTotation = Quaternion.Euler(xRotation, 0, 0);
        //     transform.rotation = Quaternion.Euler(0, yRotation, 0);
        // }
        // else
        // {
        //     Cursor.lockState = CursorLockMode.None;
        //     Cursor.visible = true;
        // }

    }
    void Movimento()
    {
        // Movimento para a frente (tecla "W")
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }
        // Movimento para a esquerda (tecla "A")
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsWalking", true);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime); // Rotação para a esquerda
        }
        // Movimento para a direita (tecla "D")
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); // Rotação para a direita
            animator.SetBool("IsWalking", true);
        }
        // Movimento para trás (tecla "S")
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }

        // Verifica se a tecla de espaço é pressionada para pular
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            // Aplica uma força vertical para fazer o personagem pular
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
            animator.SetBool("IsWalking", true);
        }
    }
    // Resetar o contador de pulos quando colidir com o chão
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

    void cameraMove()
    {

    }
}

