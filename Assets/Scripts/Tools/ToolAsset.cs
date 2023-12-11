using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tools/Tools Object")]



public class ToolAsset : ScriptableObject
{

    public enum toolType { preuan, water, havest, seed}

    public string toolName;
    public Sprite toolSprite;
    public int toolPrice;
    public toolType tool_type;
    public Sprite[] seedState;
    public Sprite drySeed;
    public float TimeToGlow;
    public int Amount;
    public int amountBuy;
    public int sellPrice;
    
}
