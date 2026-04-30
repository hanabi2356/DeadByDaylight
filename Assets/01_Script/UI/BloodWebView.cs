using System;
using UnityEngine;
using TMPro;
public class BloodWebView : MonoBehaviour
{
    
    public Action<int> onNodeClick;
    [SerializeField] private TextMeshProUGUI BPText;
    [SerializeField] private GameObject centerPoint;
    [SerializeField] private Transform uiRoot;
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private int nodeCount = 0;
    [SerializeField] private float nodeRadius = 0.0f;

    void Awake()
    {
        CreateCenterNode();
        LayoutNode(nodeCount, nodeRadius);
      
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

    /// <summary>
    /// 블러드웹의 가운데 점을 생성하는 함수
    /// </summary>
    public void CreateCenterNode()
    {
        Debug.Log("CreateCenterNode Call");

        GameObject center = Instantiate(centerPoint, uiRoot);
        RectTransform rect = center.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;

        center.name = "Center_Core";
    }
    /// <summary>
    /// 노드들을 배치하는 함수
    /// </summary>
    /// <param name="count">배치할 노드의 수</param>
    /// <param name="radius">중점에서 얼마나 떨어져서 그릴지</param>
    public void LayoutNode(int count, float radius)
    {
        Debug.Log("LayoutNode Call");
        for (int i = 0; i < count; i++)
        {
            float angle = i*(360.0f/count)*Mathf.Deg2Rad;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            GameObject node = Instantiate(nodePrefab, uiRoot);
            RectTransform nodeRect = node.GetComponent<RectTransform>();
            nodeRect.anchoredPosition = new Vector2(x, y);

            

            //선 긋기 함수 자리
        }
    }
}
