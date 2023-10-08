using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    private Rigidbody rb;
    public float Hiz = 5f;
    public Text zaman, can , durum , odul1, odul2, odul3;
    float zamansayaci =100;
    float cansayaci = 20;
    bool oyundevam = true;
    bool oyuntamam = false;
    public Button buton;
    float odul1sayaci = 0;
    float odul2sayaci = 0;
    float odul3sayaci = 0;

    

    

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    //topun hareketi
    private void FixedUpdate()
    {
        if (oyundevam && !oyuntamam)
        {
            

            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rb.AddForce(kuvvet * Hiz);
          
        }
        
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

       

    
    }

    //can ve zaman sayaçlarýný kontrol eder
    private void Update()
    {
        if (oyundevam && !oyuntamam)
        {
            zamansayaci -= Time.deltaTime;
            zaman.text = (int)zamansayaci + "";
        }

        else if(!oyuntamam)
        {
            durum.text = "ZAMAN DOLDU!";
            buton.gameObject.SetActive(true);

        }

        if (zamansayaci < 0)
        { oyundevam = false; }


        
    }
    //bitiþ alanýna geldiðinde kazandýrýr
    //duvarlara çarpýnca can azalýr
    //ödül toplanýr
   private void OnCollisionEnter(Collision other)
    {
        string objIsmi = other.gameObject.name;
        string objEtiket = other.gameObject.tag;
        if (objIsmi.Equals("Bitis"))
        {
            oyuntamam = true;
            durum.text = "BASARDÝN!";
            buton.gameObject.SetActive(true);

        }

         if (!objIsmi.Equals("labirentzemin") &&
             !objIsmi.Equals("dýþ duvarlar") &&
             !objIsmi.Equals("baslangic") &&
             !objEtiket.Equals("odul") )
                  
                
        { cansayaci -= 1;
            can.text = cansayaci + "";
                }

        if (cansayaci == 0)
        { oyundevam = false;
            oyuntamam = true;
            durum.text = "KAYBETTÝN!";
            buton.gameObject.SetActive(true);
        }
        //can ödülü
        if(objIsmi.Equals("odul4"))
        {
            Destroy(other.gameObject); 
            cansayaci += 2;
            can.text = cansayaci + "";
        }

        //can cezasý
        if (objIsmi.Equals("ceza1"))
        {
            Destroy(other.gameObject);
            cansayaci -= 1;
            can.text = cansayaci + "";
        }



        // ödül toplar ve sayaca iþler

        //kitap ödülü
        if (objIsmi.Equals("odul1"))
        { Destroy(other.gameObject);
            odul1sayaci += 1;
            odul1.text = odul1sayaci + "";
        }

        //arkadaþ ödülü
        if (objIsmi.Equals("odul2"))
        {
            Destroy(other.gameObject);
            odul2sayaci += 1;
            odul2.text = odul2sayaci + ""; 
        }

        //zaman ödülü
        if (objIsmi.Equals("odul5"))
        {
            Destroy(other.gameObject);
            zamansayaci += 10;
            zaman.text = zamansayaci + "";
        }


        //mutluluk ödülü
        if (objIsmi.Equals("odul3"))
        {
            Destroy(other.gameObject);
            odul3sayaci += 1;
            odul3.text = odul3sayaci + "";
        }

        //mutsuzluk ceza
        if (objIsmi.Equals("ceza3"))
        {
            Destroy(other.gameObject);
            odul3sayaci -= 1;
            odul3.text = odul3sayaci + "";
        }

        //arkadaþ ceza
        if (objIsmi.Equals("ceza2"))
        {
            Destroy(other.gameObject);
            odul2sayaci -= 1;
            odul2.text = odul2sayaci + "";
        }
    }

    

}
