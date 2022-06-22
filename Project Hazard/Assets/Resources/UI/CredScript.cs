using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class CredScript : MonoBehaviour
{
    private Label CredBack;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        CredBack = root.Q<Label>("CredBack");
        
    }

    // Update is called once per frame
    void Update()
    {
        CredBack.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("MainMenu"));
    }
}
