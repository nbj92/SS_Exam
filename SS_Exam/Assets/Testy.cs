using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class Testy : MonoBehaviour
{
    public TestObject testObject;

    public int score; 
    public Vector3 tempTransformPosition;

public string onsdagfbnhcgmnn;

public float fridag; 


    // Start is called before the first frame update
    void Start()
    {
        score = SaveLoad.LoadInt("Test"); 
        tempTransformPosition = SaveLoad.LoadVector3("fsadjkhasdhuocaecrhil");
        testObject = SaveLoad.LoadObject<TestObject>("to");
        onsdagfbnhcgmnn = SaveLoad.LoadString("hgfiyg"); 
        fridag = SaveLoad.LoadFloat("mini"); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) {
             SaveAll();
        }  
    }

    private void SaveAll() {
        SaveLoad.SaveInt("Test", score);
        SaveLoad.SaveVector3("fsadjkhasdhuocaecrhil", tempTransformPosition);
        SaveLoad.SaveObject("to", testObject);
        SaveLoad.SaveString("hgfiyg", onsdagfbnhcgmnn); 
        SaveLoad.SaveFloat("mini", fridag); 
    }
}


[System.Serializable]
public class TestObject {
    public int testInt;
    public float testFloat;
    public string testString;
}