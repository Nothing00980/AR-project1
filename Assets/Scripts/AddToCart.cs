using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AddToCart : MonoBehaviour
{
    private SimpleBarcodeScanner sc;
    private TextMeshProUGUI itemQuantity ;
    public GameObject productPanel;
    public GameObject goCartButton;
    public int qty=0;

    public void GoToCart() {
        SceneManager.LoadScene(1);
    }

    public void IncreaseQuantity()
    {
        itemQuantity = GameObject.FindGameObjectWithTag("ItemQuantity").GetComponent<TextMeshProUGUI>();
        qty++;
        itemQuantity.text = qty.ToString();
    }

    public void DecreaseQuantity() {
        itemQuantity = GameObject.FindGameObjectWithTag("ItemQuantity").GetComponent<TextMeshProUGUI>();
        if (qty > 0)
            qty--;
        itemQuantity.text = qty.ToString();
    }



    public void CartMethod() {
        itemQuantity = GameObject.FindGameObjectWithTag("ItemQuantity").GetComponent<TextMeshProUGUI>();

        sc = GameObject.FindGameObjectWithTag("Barcode").GetComponent<SimpleBarcodeScanner>();


        if (itemQuantity.text != "0")
        {
            CartList.ProductDetail a = new CartList.ProductDetail();

            a.name = sc.name_text.text;

            int.TryParse(sc.price_text.text, out a.price);



            //if (CartList.productList.Count > 0)
            for (int i = 0; i < CartList.productList.Count; i++)
            {
                if (CartList.productList[i].name == a.name)
                {
                    int x;
                    Debug.Log("inside"+CartList.productList[i].quantity);
                    int.TryParse(itemQuantity.text, out x);
                    CartList.productList[i].quantity += x;
                    this.qty = 0;
                    itemQuantity.text = this.qty.ToString();
                    Debug.Log("name: " + CartList.productList[i].name + " qty: " + CartList.productList[i].quantity + " price: " + CartList.productList[i].price + " count: " + CartList.productList.Count);
                    return;
                }
            }
            Debug.Log("name: " + a.name + " qty: " + "first ");
            // a.quantity++;

            int.TryParse(itemQuantity.text, out a.quantity);
            CartList.productList.Add(a);
            this.qty = 0;
            itemQuantity.text = this.qty.ToString();


        }

        
       
    }
    
    
}
