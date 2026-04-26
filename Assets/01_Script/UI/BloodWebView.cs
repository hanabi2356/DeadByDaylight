using System;
using UnityEngine;
using TMPro;
public class BloodWebView : MonoBehaviour
{
    
    public Action<int> onNodeClick;
    [SerializeField] private TextMeshProUGUI BPText;
    [SerializeField] private GameObject centerPoint;
    [SerializeField] private Transform uiRoot;
    void Awake()
    {
        CreateCenterNode();
    }

    void Update()
    {
        
    }
    /// <summary>
    /// BloodPoint의 Text를 갱신하는 함수
    /// </summary>
    /// <param name="currentBP">현재 가지고 있는 BloodPoint</param>
    public void UpdateBPText(int currentBP)
    {
        BPText.text = currentBP.ToString("N0");
    }
    /// <summary>
    /// 노드를 클릭 했을 때 구매 및 이펙트 같은 시각적인 효과를 재생하는 함수
    /// </summary>
    /// <param name="nodeId">클릭한 노드의 id</param>
    public void PlayPurchaseEffect(int nodeId)
    {
        Debug.Log($"{nodeId} 구매");
    }
    public void OnClickNode(int id)
    {
        onNodeClick.Invoke(id);
    }
    public void CreateCenterNode()
    {
        GameObject center = Instantiate(centerPoint, uiRoot);
        RectTransform rect = center.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;

        center.name = "Center_Core";
    }
    
}
