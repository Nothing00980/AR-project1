using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using System.Collections;


[System.Serializable]
public class respose
{
    public bool success;
    public productdetails item;
}
[System.Serializable]
public class productdetails{

    public string _id;
    public string barcode;
    public string productName;
    public int quantity;
    public int price;
    public string calories;
    public string protein;
    public string sodium;
    public string sugar;
    public int __v;
}

public class sendbarcode : MonoBehaviour
{
    public static int count=0;
    public string barcode;
    string backendURL = "http://localhost:3000/barcode-fetch";

    public respose pd;
    public Products pb;

    //[SerializeField] private SimpleBarcodeScanner SBS;
    [SerializeField] private float reqInterval = 2f;
    
    private float timer=0f;
    private void Awake ()
    {
        // Assign the pop script reference
        //popscript = GameObject.Find("controller").GetComponent<pop>();
        //popscript.OnClickDisableObject();

        // Change the text values using the pop script methods
        
    }
    //private void FixedUpdate()
    //{
    //    barcode = SimpleBarcodeScanner.barcodeData;
    //    if(SBS.ProductPanel.activeInHierarchy)
    //    {

    //        timer += Time.deltaTime;         
    //         if (timer >= reqInterval) {
    //            sendingbarcode();
    //            timer -= reqInterval;
    //        }
    //    }

    //}
    private void OnEnable()
    {
        sendingbarcode();
    }


    public void sendingbarcode(){
        worker();
    }

    public void worker(){
        count++;
        Debug.Log(count);
        Debug.Log(barcode);
         try
        {
            
       
   
        string jsonData = "{\"barcode\":\"" + barcode + "\"}";

        byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);

        Debug.Log(backendURL);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(backendURL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = byteArray.Length;
            Debug.Log("11111111111111111111111111111111111111111111111111");
        using (Stream dataStream = request.GetRequestStream())
        {
            dataStream.Write(byteArray, 0, byteArray.Length);
        }
            Debug.Log("2222222222222222222222222222222222222");
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
                Debug.Log("3333333333333333333333333333333333333333333");
            if (response.StatusCode == HttpStatusCode.OK)
                {

            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream);
                string responseFromServer = reader.ReadToEnd();
                        Debug.Log(pd.item.productName + "99999999999999999999999999999999999");
                        pd = JsonUtility.FromJson<respose>(responseFromServer);
                Debug.Log(responseFromServer);
                        Debug.Log(pd.item.barcode);

                        Debug.Log(pd.item.productName + "++++++++++++++++++++++++++++++++++++");
                        pb.populateProducts(pd.item.barcode, pd.item.productName, pd.item.price, pd.item.quantity, float.Parse(pd.item.calories), float.Parse(pd.item.protein), float.Parse(pd.item.sodium), float.Parse(pd.item.sugar));
                        Debug.Log(pd.item.productName + "++++++++++++++++++++++++++++++++++++");


                        // SceneManager.LoadScene("verify-otp");

                    }
        }
        else{
                //popscript.onclickenable();
                //popscript.ChangeTextValuehead("Warning!");
                //popscript.ChangeTextValuemaintext(response.StatusCode.ToString());

             Debug.LogError("Error: " + response.StatusCode);
        }
        }
        
    } catch (WebException ex)
        {
            // Handle exceptions
            Debug.LogError("WebException: " + ex.Message);
            //popscript.onclickenable();
            //popscript.ChangeTextValuehead("Error");
            //popscript.ChangeTextValuemaintext(ex.Message);
        }
        catch (System.Exception ex)
        {
            // Handle other exceptions
            Debug.LogError("Exception: " + ex.Message);
            //popscript.onclickenable();
            //popscript.ChangeTextValuehead("Error");
            //popscript.ChangeTextValuemaintext(ex.Message);
        }
    }

    }

