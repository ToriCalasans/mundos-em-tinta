using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;
    bool player_detection = false;

    void Update()
    {
        // if (player_detection && Input.GetKeyDown(KeyCode.F) && !PlayerMovement.dialogue)
        if (player_detection && Input.GetKeyDown(KeyCode.F) && !Personagem.dialogue)
        {
            canva.SetActive(true);
            // PlayerMovement.dialog = true;
            Personagem.dialogue = true;
            NewDialogue("Olá");
            NewDialogue("Eu sou a Alice");
            NewDialogue("Seja bem vindo");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        // template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = OnTriggerExit;
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
