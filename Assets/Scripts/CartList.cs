using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartList : MonoBehaviour
{   public class ProductDetail {
        public string name;
        public int price;
        public int quantity=0;


        
    }


    public static List<ProductDetail> productList = new List<ProductDetail>();

    
}
