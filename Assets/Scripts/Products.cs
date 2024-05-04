
using UnityEngine;
[CreateAssetMenu]
public class Products : ScriptableObject
{

    public string code;
    public string name;
    public int price;
    public int weight;
    public float cal;
    public float protein;
    public float sodium;
    public float sugar;

    public void populateProducts(string code, string name, int price, int weight, float cal, float protein, float sodium, float sugar) {
        this.code = code;
        this.name = name;
        this.price = price;
        this.weight = weight;
        this.cal = cal;
        this.protein= protein;
        this.sodium = sodium;
        this.sugar = sugar;
    
    }
  
}
