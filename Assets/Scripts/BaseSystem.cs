using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSystem : MonoBehaviour
{
    [SerializeField]
    private Color defaultColor, HoverColor;
    SpriteRenderer sprite;

    public bool Ispreuan, IsWater, IsPlant, IsHavest;

    [SerializeField]
    private Sprite DefaultSprite, PreuanNoWater, PreuanAndWater;

    [SerializeField]
    private float delayToPreuan , delayToWater;

    [SerializeField]
    private float PreuanDelay, WaterDelay;

    [SerializeField]
    private SeedSystem seedPlace;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        setSprite();
        delaySystem();
    }

    void setSprite()
    {
        if (Ispreuan)
        {
            if (!IsWater)
            {
                //No water
                sprite.sprite = PreuanNoWater;
            }
            else
            {
                //Add water
                sprite.sprite = PreuanAndWater;
            }
        }
        else
        {
            sprite.sprite = DefaultSprite;
        }
    }

    void delaySystem()
    {
        if (!seedPlace.glowing)
        {
            PreuanDelay -= Ispreuan && !IsWater ? Time.deltaTime : 0;
            PreuanDelay = Mathf.Clamp(PreuanDelay, 0.0f, delayToPreuan);

            WaterDelay -= IsWater ? Time.deltaTime : 0;
            WaterDelay = Mathf.Clamp(WaterDelay, 0.0f, delayToWater);
        }

        if (PreuanDelay <= 0)
        {
            Ispreuan = false;
        }

        if (WaterDelay <= 0)
        {
            IsWater = false;
        }
    }

    public void onRay()
    {
        sprite.color = HoverColor;
        if (Input.GetMouseButton(0))
        {
            if (ToolsManager.instance.nowTool != null)
            {
                if (ToolsManager.instance.nowTool.tool_type == ToolAsset.toolType.preuan)
                {
                    Ispreuan = true;
                    PreuanDelay = delayToPreuan;
                }

                if (ToolsManager.instance.nowTool.tool_type == ToolAsset.toolType.water)
                {
                    IsWater = true;
                    WaterDelay = delayToWater;
                }

                if (ToolsManager.instance.nowTool.tool_type == ToolAsset.toolType.havest)
                {
                    if (IsHavest)
                    {
                        baseReset();
                    }
                }

                if (ToolsManager.instance.nowTool.tool_type == ToolAsset.toolType.seed)
                {
                    if (Ispreuan && ToolsManager.instance.nowTool.Amount > 0)
                    {
                        if (!IsPlant)
                        {
                            ToolsManager.instance.nowTool.Amount -= 1;
                        }
                        IsPlant = true;
                        seedPlace.setSeed(ToolsManager.instance.nowTool);
                    }
                    
                }

                if (ToolsManager.instance.nowTool.tool_type == ToolAsset.toolType.bone)
                {
                    if (!IsHavest && ToolsManager.instance.nowTool.Amount > 0)
                    {
                        seedPlace.BoneActive();
                        ToolsManager.instance.nowTool.Amount -= 1;
                    }
                    
                }
            }
        }
    }

    void baseReset()
    {
        IsPlant = false;
        IsHavest = false;
        seedPlace.resetPlace();
    }

 //   private void OnMouseEnter()
  //  {
  //      sprite.color = HoverColor;
  //  }

    public void NotHover()
    {
        sprite.color = defaultColor;
    }
}
