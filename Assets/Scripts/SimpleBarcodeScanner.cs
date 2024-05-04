using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.SceneManagement;

public class SimpleBarcodeScanner : MonoBehaviour
{
    public TextMeshProUGUI name_text, weight_text, cal_text, protein_text, sugar_text, sodium_text,price_text;
    // public TMPro.TextMeshProUGUI barcodeAsText;
    public GameObject ProductPanel,goCartButton;
    BarcodeBehaviour mBarcodeBehaviour;
   // public ProductInfo p,p1,p2,p3;
    //public AddToCart atc;
    //public TextMeshProUGUI qtyText;
    public static string barcodeData;

    public Products prod;

    

    public class ProductInfo
    {   
        protected long ID;
        public string name;
        public int weight;
        public float calories;
        public float protein;
        public float sugar;
        public float sodium;
        public int price;

        public ProductInfo(long ID, string name,int price, int weight, float calories, float protein, float sugar, float sodium)
        {
            this.ID = ID;
            this.name = name;
            this.price = price;
            this.weight = weight;
            this.calories = calories;
            this.protein = protein;
            this.sugar = sugar;
            this.sodium = sodium;

        }

    }

    void Start()
    {
         //p1 = new ProductInfo(8901491361026, "Kurkure",10,36, 196.56f, 2.0f, 0.18f, 0.34f);
         //p2 = new ProductInfo(7622201440046, "Dairy Milk",10, 12, 63f, 0.67f, 7.32f, 0.01f);
         //p3 = new ProductInfo(8902519009852, "Cake", 10, 12, 63f, 0.67f, 7.32f, 0.01f);

        mBarcodeBehaviour = GetComponent<BarcodeBehaviour>();
    }

    
    void Update()
    {
        
        if (mBarcodeBehaviour != null && mBarcodeBehaviour.InstanceData != null)
        {
            barcodeData = mBarcodeBehaviour.InstanceData.Text;

            ProductPanel.SetActive(true);

            goCartButton.SetActive(false);
            //if (mBarcodeBehaviour.InstanceData.Text == "8901491361026")
            //    p = p1;
            //else if (mBarcodeBehaviour.InstanceData.Text == "7622201440046")
            //    p = p2;
            //else if (mBarcodeBehaviour.InstanceData.Text == "8902519009852")
            //    p = p3;

            name_text.text = prod.name;
            price_text.text = prod.price.ToString() ;
            
            weight_text.text = prod.weight.ToString() + "g";
            cal_text.text = prod.cal.ToString() + " kcal";
            protein_text.text = prod.protein.ToString() + "g";
            sugar_text.text = prod.sugar.ToString() + "g";
            sodium_text.text = prod.sodium.ToString() + "g";
            

            
            //barcodeAsText.text = mBarcodeBehaviour.InstanceData.Text;

        }
        else
        {
            //atc.qty = 0;  // set quantity zero
            //qtyText.text = atc.qty.ToString();

            
            ProductPanel.SetActive(false);
            goCartButton.SetActive(true);
            
            


            //barcodeAsText.text = "";
        }
    }

    
}