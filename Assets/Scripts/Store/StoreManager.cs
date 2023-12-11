using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField]
    private ToolAsset[] product;

    [SerializeField]
    private GameObject productPrefab;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private TextMeshProUGUI coinTotal;

    float nowMoney = 0;
    
    void Start()
    {
        foreach (var item in product)
        {
            GameObject p = Instantiate(productPrefab);
            p.GetComponent<Product>().setProduct(item);
            p.transform.SetParent(content , false);
        }
    }

    private void Update()
    {
        int m = TotalSystem.Instance.Money;
 
        if (nowMoney > m)
        {
            nowMoney -= (m / 2.0f) * Time.deltaTime;
        }

        if (nowMoney < m)
        {
            nowMoney += (m / 2.0f) * Time.deltaTime;
        }

        nowMoney = Mathf.Clamp(nowMoney , 0.0f , m);

        coinTotal.text = nowMoney > 0 ? ((int)nowMoney).ToString("#,#") : "0";
    }

}
