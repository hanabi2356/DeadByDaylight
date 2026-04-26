using UnityEngine;
using UnityEngine.UI;

public class BloodWebModel : MonoBehaviour
{
    public int mCurrBP { get; private set; } = 100000;

    void Awake()
    {
        
    }

    void Update()
    {
        
    }
    public void SpendBP(int value)
    {
        mCurrBP -= value;
    }
    /// <summary>
    /// 재화가 충분한지 검사하는 함수
    /// </summary>
    /// <param name="value">클릭한 노드의 재화</param>
    /// <returns></returns>
    public bool CanSpend(int value)
    {
        return mCurrBP >= value;
    }
    /// <summary>
    /// 그래프 생성 함수
    /// </summary>
    /// <param name="currLevel">현재 캐릭터의 블러드 웹 레벨</param>
    public void CreateGraph(int currLevel)
    {

    }
}
