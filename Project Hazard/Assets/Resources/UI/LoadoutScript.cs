using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoadoutScript : MonoBehaviour
{
    private VisualElement VisElTridentBG;
    private VisualElement VisElMultiThrowBG;
    private VisualElement VisElPlasmaBG;
    private VisualElement visElStartRunBtn;
    private Label BacktoMainBtn;
    Color enterMouse = new Color(189f/255f, 13f/255f, 13f/255f, 0.75f);
    Color exitMouse = new Color(84f/255f, 87f/255f, 90f/255f, 0.75f);
    
    private VisualElement VisElSumPrimary;
    public Texture2D tridentIcon;
    public Texture2D plasmaIcon;
    Scene thisScene;
    
    public int characterToggle = 0;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        VisElTridentBG = root.Q<VisualElement>("TridentPrimary");
        VisElMultiThrowBG = root.Q<VisualElement>("TridentMulti");
        VisElPlasmaBG = root.Q<VisualElement>("PlasmaPrimary");
        visElStartRunBtn = root.Q<VisualElement>("StartRun");
        BacktoMainBtn = root.Q<Label>("BacktoMainMenu");

        //summary icons
        VisElSumPrimary = root.Q<VisualElement>("primSum");
    }

    // Update is called once per frame
    void Update()
    {

        BacktoMainBtn.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("MainMenu"));

        var root = GetComponent<UIDocument>().rootVisualElement;
        thisScene = SceneManager.GetActiveScene();
        if(thisScene.name == "LoadoutSelectV1")
        {
            root.style.display = DisplayStyle.Flex;
        }
        if(thisScene.name != "LoadoutSelectV1")
        {
            root.style.display = DisplayStyle.None;
        }
        
        if(characterToggle == 0)
        {
            VisElTridentBG.style.backgroundColor = enterMouse;
            VisElSumPrimary.style.backgroundImage = tridentIcon;

        }
        if(characterToggle == 1)
        {
            VisElPlasmaBG.style.backgroundColor = enterMouse;
            VisElSumPrimary.style.backgroundImage = plasmaIcon;
        }

        //Trident Primary
        VisElTridentBG.RegisterCallback<MouseEnterEvent>(ev => VisElTridentBG.style.backgroundColor = enterMouse);
        VisElTridentBG.RegisterCallback<MouseLeaveEvent>(ev => VisElTridentBG.style.backgroundColor = exitMouse);
        VisElTridentBG.RegisterCallback<ClickEvent>(ev => SetTrident());
        
        //Trident Multi Throw
        VisElMultiThrowBG.RegisterCallback<MouseEnterEvent>(ev => VisElMultiThrowBG.style.backgroundColor = enterMouse);
        VisElMultiThrowBG.RegisterCallback<MouseLeaveEvent>(ev => VisElMultiThrowBG.style.backgroundColor = exitMouse);
    
        //Plasma Primary
        VisElPlasmaBG.RegisterCallback<MouseEnterEvent>(ev => VisElPlasmaBG.style.backgroundColor = enterMouse);
        VisElPlasmaBG.RegisterCallback<MouseLeaveEvent>(ev => VisElPlasmaBG.style.backgroundColor = exitMouse);
        VisElPlasmaBG.RegisterCallback<ClickEvent>(ev => SetPlasma());


        //Start Run button
        visElStartRunBtn.RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("Stage_1"));
    
    }
    void SetTrident()
    {
        characterToggle = 0;
        VisElPlasmaBG.style.backgroundColor = exitMouse;
    }        
    void SetPlasma()
    {
        characterToggle = 1;
        VisElTridentBG.style.backgroundColor = exitMouse;
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
