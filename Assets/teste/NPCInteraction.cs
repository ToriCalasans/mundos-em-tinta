// NPCInteraction.cs
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Dialogue dialogue; // Diálogo associado ao NPC
    public KeyCode interactionKey = KeyCode.F; // Tecla de interação
    public GameObject interactionUI; // Objeto da UI de interação
    private bool isInRange = false; // Verifica se o jogador está na área de interação

    void Update()
    {
        if (isInRange && Input.GetKeyDown(interactionKey))
        {
            TriggerDialogue(); // Inicia o diálogo quando a tecla é pressionada
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true; // Define a interação como possível quando o jogador entra na área
            // Adicione aqui lógica para exibir um aviso de interação, se desejar
            interactionUI.SetActive(true); // Ativa a UI de interação quando o jogador entra na área
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false; // Define a interação como não possível quando o jogador sai da área
                               // Adicione aqui lógica para esconder o aviso de interação, se desejar
            interactionUI.SetActive(false); // Desativa a UI de interação quando o jogador sai da área
        }
    }

    void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); // Inicia o diálogo usando o gerenciador de diálogos
    }


    void Start()
    {
        interactionUI.SetActive(false); // Garante que a UI de interação está desativada no início
    }


}
/*
public Dialogue dialogue;: O diálogo associado ao NPC.
public KeyCode interactionKey = KeyCode.F;: A tecla usada para iniciar a interação.
private bool isInRange = false;: Verifica se o jogador está na área de interação.
void Update(): Verifica se a tecla de interação foi pressionada.
void OnTriggerEnter(Collider other): Ativado quando o jogador entra na área de interação.
void OnTriggerExit(Collider other): Ativado quando o jogador sai da área de interação.
void TriggerDialogue(): Inicia o diálogo usando o gerenciador de diálogos quando a tecla de interação é pressionada.
*/