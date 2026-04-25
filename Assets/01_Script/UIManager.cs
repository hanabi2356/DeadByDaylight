using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIType
{
    None,
    SelectedCharacter,
    Inventory,
    BloodWeb,
    Setting
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; }
    [SerializeField] private GameObject UIPanel;
    public List<Button> mButtons = new List<Button>();
    [SerializeField] private bool mUIOpen = false;
    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        foreach(Button b in mButtons)
        {
            b.onClick.AddListener(PanelPopUp);
        }
    }

    void Update()
    {
        
    }

    /// <summary>
    /// UI의 백그라운드가 되는 Panel On/Off 결정
    /// </summary>
    private void PanelPopUp()
    {
        mUIOpen = mUIOpen ? false : true;

        if(mUIOpen)
        {
            UIPanel.SetActive(true);
        }
        else
        {
            UIPanel.SetActive(false);
        }

    }

}
