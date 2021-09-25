using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash: MonoBehaviour
{

    public float waitTime;
    public Text textGO;
    public string text;

    public void Start(){
        Invoke("Type", waitTime);
    }
    private void Type(){

        textGO.text = "";
        StartCoroutine(TextCR());
    }
    IEnumerator TextCR(){
        foreach(char abc in text){
            textGO.text += abc;
            yield return new WaitForSeconds(0.05f);
        }
    }

}
