// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class Continue : MonoBehaviour {

//     public ContinueObject continueObject; 

//     public Vector3 tempTransformPosition;

//     void Start()
//     {

//         tempTransformPosition = SaveLoad.LoadVector3("Position")

//     }

//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.S)) {
//             SaveAll(); 
//         }
//     }

//     private void SaveAll() {
//         SaveLoad.SaveVector3("Position", tempTransformPosition); 
//     }
// }

// [System.Serializable]
// public class ContinueObject {
//     public int testInt;
//     public float testFloat;
//     public string testString;
// }

// using UnityEngine. SceneManagement;


// public class Continue : MonoBehaviour
// {
//     private Vector3 playerPosition; 

//     public void OpenMenu() 
//     {
//         playerPosition = FindPlayer().transform.position; 

//     }

//     public void BackToGame()
//     {
//         FindPlayer().transform.position = playerPosition; 

//         //Lukker menuen 
//         gameObject.SetActive(false); 
//     }
// }