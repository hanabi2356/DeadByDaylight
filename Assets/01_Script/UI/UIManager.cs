using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public enum UIType
{
    None,
    SelectedCharacter,
    Loadout,
    BloodWeb,
    Setting
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }

    [Header("UI State")]
    [SerializeField] private GameObject mUIPanel;
    [SerializeField] private bool mUIOpen = false;
    private UIPresenter mCurrPresenter;

    [Header("UI Resource")]
    [SerializeField] private Transform mUIRoot; //panel 위에 생성될거기 때문에 panel지정
    [SerializeField] private BloodWebView mBloodWebViewPrefab;

    [Header("Side Menu Buttons")]
    [SerializeField] private List<Button> sideButtons = new List<Button>();


    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        InitSideButton();
    }

    void Update()
    {
        
    }
    public void InitSideButton()
    {
        sideButtons[0].onClick.AddListener(() => OpenUI(UIType.SelectedCharacter));
        sideButtons[1].onClick.AddListener(() => OpenUI(UIType.Loadout));
        sideButtons[2].onClick.AddListener(() => OpenUI(UIType.BloodWeb));
        Debug.Log("Button Binding");

    }

    /// <summary>
    /// UI의 백그라운드가 되는 Panel On/Off 결정
    /// </summary>
    /// <param name="value"></param>
    private void PanelPopUp(bool value)
    {
        mUIOpen = value;
        mUIPanel.SetActive(value);
        Debug.Log("Panel Pop-Up");
    }

    public void OpenUI(UIType type)
    {
        Debug.Log("OpenUI Call");
        if(mCurrPresenter != null)
        {
            CloseUI();
        }

        if (!mUIOpen)
            PanelPopUp(true);

        switch (type)
        {
            case UIType.BloodWeb:
                BloodWebView view = Instantiate(mBloodWebViewPrefab, mUIRoot);
                mCurrPresenter = new BloodWebPresenter(new BloodWebModel(), view);
                break;
            case UIType.Loadout:

                break;
            case UIType.None:
            default:
                CloseUI();
                return;
        }

        mCurrPresenter?.Init();
    }
    public void CloseUI()
    {
        mCurrPresenter?.Clear();
        mCurrPresenter = null;
        foreach(Transform child in mUIRoot)
        {
            Destroy(child.gameObject);
        }
        PanelPopUp(false);

    }

}
