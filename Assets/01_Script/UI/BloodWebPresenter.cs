using System;
using UnityEngine;

public class BloodWebPresenter : UIPresenter
{
    private BloodWebModel BWModel;
    private BloodWebView BWView;
    
    public BloodWebPresenter(BloodWebModel model, BloodWebView view)
    {
        BWModel = model;
        BWView = view;
    }

    public override void Clear()
    {
        BWView.onNodeClick -= NodeClick;
    }

    public override void Init()
    {
        BWView.UpdateBPText(BWModel.mCurrBP);

        BWView.onNodeClick += NodeClick;
    }
    private void NodeClick(int nodeId)
    {
        int price = 2000;
        if (BWModel != null)
        {
            if(BWModel.CanSpend(price))
            {
                BWModel.SpendBP(price);
                BWView.UpdateBPText(BWModel.mCurrBP);
                Debug.Log($"{nodeId}구매 성공");
            }
        }
    }

}
