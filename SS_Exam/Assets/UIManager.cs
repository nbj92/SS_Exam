using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thrakal;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public CanvasGroup labGroup;
    [SerializeField] public CanvasGroup worldGroup;

    public CanvasGroup activeGroup;

   

    public void ShowUILayout(UILayouts layout)
    {

        CanvasGroup currentLayout = null;
        switch (layout )
        {
            case UILayouts.World:
                currentLayout = worldGroup;
                break;
            case UILayouts.Lab:
                currentLayout = labGroup;
                break;
        }

        //currentLayout.alpha = 1;
        //currentLayout.blocksRaycasts = true;
        //currentLayout.interactable = true;

        if( activeGroup != null )
        {
            //activeGroup.alpha = 0;
            //activeGroup.blocksRaycasts = false;
            //activeGroup.interactable = false;
            if (activeGroup != currentLayout)
            {
                activeGroup.gameObject.SetActive(false);
            }
        }

        
        if(activeGroup != currentLayout)
        {
            currentLayout.gameObject.SetActive(true);
            activeGroup = currentLayout;
        }
    }
}

public enum UILayouts
{
    World,
    Lab
}