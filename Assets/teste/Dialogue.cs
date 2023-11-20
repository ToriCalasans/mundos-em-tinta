// Dialogue.cs
[System.Serializable]
public class Dialogue
{
    public string speakerName;
    // [TextArea(3, 10)]
    public string[] sentences; 
}
/*
System.Serializable: Permite que a classe seja serializada e exibida no Unity Editor.
public string speakerName;: O nome do falante no diálogo.
[TextArea(3, 10)]: Atributo que permite um campo de texto multilinha no Unity Editor.
public string[] sentences;: Um array de strings representando as sentenças do diálogo.
*/