using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;
    bool player_detection = false;
    List<string> dialogues = new List<string>();
    int currentDialogueIndex = 0;

    void Start()
    {
        // Adicione os diálogos à lista no início ou quando desejar.
        dialogues.Add("Olá");
        dialogues.Add("Eu sou a Alice");
        dialogues.Add("Seja bem vindo");
    }

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F) && !Personagem.dialogue)
        {
            canva.SetActive(true);
            Personagem.dialogue = true;
            ShowNextDialogue();
        }
    }

    void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Count)
        {
            NewDialogue(dialogues[currentDialogueIndex]);
            currentDialogueIndex++;
        }
        else
        {
            // Todos os diálogos foram exibidos, reinicie ou faça o que for necessário.
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Alain")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }
}
