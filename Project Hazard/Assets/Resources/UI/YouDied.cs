using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class YouDied : MonoBehaviour
{
    BaseStats baseStatsScript;
    ExpSystem expScript;
    Scene disScene;
    private VisualElement GameOverUI;
    //End-of-run Statistics
    public float eoRAtk;
    public float eoRMaxHealth;
    public float eoRSpeed;
    public float eoRCritRate;
    public string eoRTime;
    //
    private Label labAtk;
    private Label labSpd;
    private Label labHealth;
    private Label labCrit;
    private Label labTime;

    private Label labRetry;
    private Label labExit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        disScene = SceneManager.GetActiveScene();
        baseStatsScript = FindObjectOfType<BaseStats>();
        GameOverUI = GetComponent<UIDocument>().rootVisualElement;
        labAtk = GameOverUI.Q<Label>("AttackLabel");
        labSpd = GameOverUI.Q<Label>("SpeedLabel");
        labHealth = GameOverUI.Q<Label>("HealthLabel");
        labCrit = GameOverUI.Q<Label>("CriticalRateLabel");
        labTime = GameOverUI.Q<Label>("TimeElapsedLabel");

        labRetry = GameOverUI.Q<Label>("RetryButton");
        labExit = GameOverUI.Q<Label>("ExitButton");
        GameOverUI.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        labAtk.text = $"Base Attack: {eoRAtk}";
        labSpd.text = $"Speed: {eoRSpeed}";
        labHealth.text = $"Max Health: {eoRMaxHealth}";
        labCrit.text = $"Critical Hit Rate: {100*eoRCritRate}%";
        labTime.text = eoRTime;
        
    }
    public void RetryScreen()
    {
        Debug.Log("Display GameOver UI");
        GameOverUI.style.display = DisplayStyle.Flex;
        labRetry.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("LoadoutSelectV1"));
        labExit.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("MainMenu"));
    }
}
