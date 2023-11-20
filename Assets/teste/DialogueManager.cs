// DialogueManager.cs
using UnityEngine.UIElements;
using UnityEngine;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Componentes")]
    public TextElement nameText; // Campo de texto para o nome do falante
    public TextElement dialogueText; // Campo de texto para as sentenças do diálogo
    private Queue<string> sentences; // Fila para armazenar as sentenças do diálogo

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.speakerName; // Define o nome do falante na UI

        sentences.Clear(); // Limpa a fila de sentenças

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // Adiciona cada sentença à fila
        }

        DisplayNextSentence(); // Exibe a próxima sentença
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(); // Chama a função de encerramento do diálogo
            return;
        }

        string sentence = sentences.Dequeue(); // Pega a próxima sentença da fila
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); // Inicia a animação de digitação
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; // Limpa o campo de texto do diálogo

        // Exibe a sentença letra por letra para criar um efeito de digitação
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter; // Adiciona a letra ao campo de texto
            yield return null; // Aguarda um quadro antes da próxima letra
        }
    }

    void EndDialogue()
    {
        // Adicione aqui qualquer lógica que você queira quando o diálogo terminar
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Avança para a próxima sentença com a tecla de espaço
        {
            DisplayNextSentence();
        }
    }
}


/*
public TextMeshProUGUI nameText; e public TextMeshProUGUI dialogueText;: Referências aos campos de texto na UI para o nome do falante e as sentenças do diálogo.
private Queue<string> sentences;: Fila para armazenar as sentenças do diálogo.
void StartDialogue(Dialogue dialogue): Inicia o diálogo e configura o nome do falante na UI.
public void DisplayNextSentence(): Exibe a próxima sentença do diálogo.
IEnumerator TypeSentence(string sentence): Exibe a sentença letra por letra para criar um efeito de digitação.
void EndDialogue(): Chamado quando todas as sentenças do diálogo foram exibidas.
*/