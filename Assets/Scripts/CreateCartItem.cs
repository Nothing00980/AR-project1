using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateCartItem : MonoBehaviour
{
    public GameObject itemCart;
    public GameObject content;
    TextMeshProUGUI[] itemInfo;
    public TextMeshProUGUI totalPrice;
    void Start()
    {
       
        
        for (int i = 0; i < CartList.productList.Count; i++)
        {
            
            itemInfo =itemCart.GetComponentsInChildren<TextMeshProUGUI>();
           // Debug.Log("+++++++"+ CartList.productList[i].name + "+++++++" + CartList.productList[i].price.ToString());

            itemInfo[0].text = CartList.productList[i].name;
           // Debug.Log(CartList.productList[i].name);

            itemInfo[1].text = CartList.productList[i].price.ToString()+"/-";
           // Debug.Log(CartList.productList[i].price.ToString());

            itemInfo[2].text = "x" + CartList.productList[i].quantity.ToString();
           //  Debug.Log(CartList.productList[i].quantity.ToString());

            Instantiate(itemCart, content.transform);
        }






        int total = 0;
        for (int i = 0; i < CartList.productList.Count; i++) {

            total+=CartList.productList[i].price* CartList.productList[i].quantity; 
        }

        totalPrice.text = total.ToString() + "/-";
    }

    public void PayButton() {
        CartList.productList.Clear();
        SceneManager.LoadScene(0);
    }

    public void BackButton()
    {
        //CartList.productList.Clear();
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame

}
