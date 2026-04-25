using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour, IBTNClick
{
    public Button button;
    void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    void Update()
    {

    }
    public void OnClick()
    {
        Debug.Log("Click");
    }

    public void Activate()
    {
        Debug.Log("Click");
    }

    public void Deactivate()
    {
        throw new System.NotImplementedException();
    }
}
