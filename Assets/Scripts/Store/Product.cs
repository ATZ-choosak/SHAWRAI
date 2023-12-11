using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField]
    private ToolAsset product;

    [SerializeField]
    private TextMeshProUGUI productName, price, total;

    [SerializeField]
    private Image icon;
    
    void Start()
    {
        if (product != null)
        {
            icon.sprite = product.toolSprite;
            productName.text = product.toolName;
            price.text = product.toolPrice.ToString();
            
        }
        
    }

    public void setProduct(ToolAsset p)
    {
        product = p;
    }

    private void Update()
    {
        total.text = product.Amount.ToString();
    }

    public void buyProduct()
    {
        if (TotalSystem.Instance.Money >= product.toolPrice)
        {
            TotalSystem.Instance.addMoney(-product.toolPrice);
            product.Amount += product.amountBuy;
        }
        
    }
}
