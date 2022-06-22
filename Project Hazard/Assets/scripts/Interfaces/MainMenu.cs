using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private Label StartRunBtn, ExitGameBtn, CredScreenBtn, OptionsBtn, OptBack, CredBack, ControlsBtn, ControlBack;
    private VisualElement menuDisplay, OptionsVisEl, CreditsVisEl, MainVisEl, ControlsVisEl;
    


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        StartRunBtn = root.Q<Label>("NewRunButton");
        ExitGameBtn = root.Q<Label>("ExitGameButton");
        CredScreenBtn = root.Q<Label>("CreditsButton");
        OptionsBtn = root.Q<Label>("OptionsButton");
        ControlsBtn = root.Q<Label>("ControlsButton");

        // new UI

        menuDisplay = root.Q<VisualElement>("Buttons");
        OptionsVisEl = root.Q<VisualElement>("OptionsBG");
        CreditsVisEl = root.Q<VisualElement>("CredBG");
        MainVisEl = root.Q<VisualElement>("MainBG");
        ControlsVisEl = root.Q<VisualElement>("ControlBG");
        

        //back buttons
        OptBack = root.Q<Label>("OptionsBack");
        CredBack = root.Q<Label>("CredBack");
        ControlBack = root.Q<Label>("ControlsBack");

        OptionsVisEl.style.display = DisplayStyle.None;
        MainVisEl.style.display = DisplayStyle.Flex;
        
    }

    // Update is called once per frame
    void Update()
    {
        StartRunBtn.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("LoadoutSelectV1"));
        ExitGameBtn.RegisterCallback<ClickEvent>(ev => Application.Quit());
        OptionsBtn.RegisterCallback<ClickEvent>(ev => OpenOptions());
        CredScreenBtn.RegisterCallback<ClickEvent>(ev => OpenCredits());
        ControlsBtn.RegisterCallback<ClickEvent>(ev => OpenControls());

        //back
        OptBack.RegisterCallback<ClickEvent>(ev => BackMain());
        CredBack.RegisterCallback<ClickEvent>(ev => BackMain());
        ControlBack.RegisterCallback<ClickEvent>(ev => BackMain());

    }

    void OpenControls()
    {
        ControlsVisEl.style.display = DisplayStyle.Flex;
        menuDisplay.style.display = DisplayStyle.None;
    }

    void OpenCredits()
    {
        CreditsVisEl.style.display = DisplayStyle.Flex;
        MainVisEl.style.display = DisplayStyle.None;

    }
    
    void OpenOptions()
    {
        OptionsVisEl.style.display = DisplayStyle.Flex;
        menuDisplay.style.display = DisplayStyle.None;
    }

    void BackMain()
    {
        OptionsVisEl.style.display = DisplayStyle.None;
        CreditsVisEl.style.display = DisplayStyle.None;
        ControlsVisEl.style.display = DisplayStyle.None;
        MainVisEl.style.display = DisplayStyle.Flex;
        menuDisplay.style.display = DisplayStyle.Flex;
    }

    
}
