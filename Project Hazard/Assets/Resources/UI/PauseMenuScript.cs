using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    HUDScript HudScript;

    public bool GamePaused = false;
    private VisualElement PauseMenuUI;
    private VisualElement OptionsVisEl;
    private VisualElement ControlsVisEl;
    private VisualElement WarningVisEl;


    private Label optBack;
    private Label ctrlBack;
    private Label labPauseTitle;
    private Label labResume;
    private VisualElement labControls;
    public VisualElement labOptions;
    private Label labCredits;
    private Label labQuit;

    private VisualElement pauseDisplay;
    public string thisSceneName;
    
    private GameObject thisPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Scene thisScene = gameObject.scene;
        HudScript = FindObjectOfType<HUDScript>();
        PauseMenuUI = GetComponent<UIDocument>().rootVisualElement;
        pauseDisplay = PauseMenuUI.Q<VisualElement>("PauseButtons");
        labPauseTitle = PauseMenuUI.Q<Label>("StageTitleLabel");
        labResume = PauseMenuUI.Q<Label>("ResumeLabel");
        labControls = PauseMenuUI.Q<VisualElement>("ControlsBtn");
        labOptions = PauseMenuUI.Q<VisualElement>("OptionsBtn");
        labCredits = PauseMenuUI.Q<Label>("CreditsLabel");

        labQuit = PauseMenuUI.Q<Label>("QuitLabel");
        optBack = PauseMenuUI.Q<Label>("OptionsBack");
        ctrlBack = PauseMenuUI.Q<Label>("CtrlBack");

        OptionsVisEl = PauseMenuUI.Q<VisualElement>("OptionsBG");
        ControlsVisEl = PauseMenuUI.Q<VisualElement>("ControlBG");
        WarningVisEl = PauseMenuUI.Q<VisualElement>("QuitWarning");


        PauseMenuUI.style.display = DisplayStyle.None;
        OptionsVisEl.style.display = DisplayStyle.None;
        ControlsVisEl.style.display = DisplayStyle.None;
        WarningVisEl.style.display = DisplayStyle.None;

        if (thisScene.name == "Stage_1")
        {
            labPauseTitle.text = "Stage 1";
        }

        if (thisScene.name == "Stage_2")
        {
            labPauseTitle.text = "Stage 2";
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                BacktoPauseUI();
                Resume();
            }
            else
            {
                Pause();
            }
        }
        



        if(GamePaused)
        {
            labResume.RegisterCallback<ClickEvent>(ev => Resume());
        }

        

        PauseMenuUI.Q<VisualElement>("OptionsBtn").RegisterCallback<ClickEvent>(ev => OpenOptions());
        PauseMenuUI.Q<VisualElement>("OptionsBack").RegisterCallback<ClickEvent>(ev => BacktoPauseUI());
        PauseMenuUI.Q<VisualElement>("ControlsBtn").RegisterCallback<ClickEvent>(ev => OpenControls());
        PauseMenuUI.Q<VisualElement>("ControlBack").RegisterCallback<ClickEvent>(ev => BacktoPauseUI());
        PauseMenuUI.Q<VisualElement>("QuitBack").RegisterCallback<ClickEvent>(ev => BacktoPauseUI());
        PauseMenuUI.Q<VisualElement>("QuitBtn").RegisterCallback<ClickEvent>(ev => OpenWarning());
        PauseMenuUI.Q<VisualElement>("QuittoMain").RegisterCallback<ClickEvent>(ev => QuitGame());



    }

    void OpenWarning()
    {
        WarningVisEl.style.display = DisplayStyle.Flex;
        pauseDisplay.style.display = DisplayStyle.None;
    }

    void OpenControls ()
    {
        ControlsVisEl.style.display = DisplayStyle.Flex;
        pauseDisplay.style.display = DisplayStyle.None;
    }

    public void OpenOptions ()
    {
        OptionsVisEl.style.display = DisplayStyle.Flex;
        pauseDisplay.style.display = DisplayStyle.None;
    }


    void Resume ()
    {
        PauseMenuUI.style.display = DisplayStyle.None;
        //ControlsVisEl.style.display = DisplayStyle.None;
        //OptionsVisEl.style.display = DisplayStyle.None;
        
        //Resume looking around when paused
        thisPlayer = GameObject.FindGameObjectWithTag("Player");
        if(thisPlayer.GetComponent<playerLookTrident>() == null)
        {
            thisPlayer.GetComponent<playerLookSword>().enabled = enabled;
        }
        if(thisPlayer.GetComponent<playerLookSword>() == null)
        {
            thisPlayer.GetComponent<playerLookTrident>().enabled = enabled;
        }
        //^Resume looking around when paused
        
        Time.timeScale = 1f;
        GamePaused = false;
        //playerLookSword.enabled = true;
        //playerLookTrident.enabled = true;
        //playerLook.enabled = true;

    }
    
    void Pause ()
    {
        //stop looking around when paused
        thisPlayer = GameObject.FindGameObjectWithTag("Player");
        if(thisPlayer.GetComponent<playerLookTrident>() == null)
        {
            thisPlayer.GetComponent<playerLookSword>().enabled = false;
        }
        if(thisPlayer.GetComponent<playerLookSword>() == null)
        {
            thisPlayer.GetComponent<playerLookTrident>().enabled = false;
        }
        //^Stop looking around when paused

        PauseMenuUI.style.display = DisplayStyle.Flex;
        //labPauseTitle.text = HudScript.thisSceneName;
        Time.timeScale = 0f;
        GamePaused = true;
        //playerLookSword.enabled = false;
        //playerLookTrident.enabled = false;
        //playerLook.enabled = false;
    }

    void BacktoPauseUI()
    {
        pauseDisplay.style.display = DisplayStyle.Flex;
        OptionsVisEl.style.display = DisplayStyle.None;
        ControlsVisEl.style.display = DisplayStyle.None;
        WarningVisEl.style.display = DisplayStyle.None;

    }

    void QuitGame()
    {
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.Find("LoadoutPrefab"));
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("You've gone to the MainMenu");
    }
}
