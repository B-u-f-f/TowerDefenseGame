// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
// public class ShopManager : MonoBehaviour
// {

//     public int[,] shopItems = new int[5,5];
//     public float coins;
//     public Text CoinsTxt;


//     // Start is called before the first frame update
//     void Start()
//     {
//         CoinsTxt.text = "Coins:"+coins.ToString();

//         // set IDs
//         shopItems[1,1] = 1;
//         shopItems[1,2] = 2;

//         // Price
//         shopItems[2,1] = 10;
//         shopItems[2,2] = 20;

//         // Quantity
//         shopItems[3,1] = 0;
//         shopItems[3,2] = 0;

//     }
//     public void Buy()
//     {
//         GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

//         if(coins >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
//         {
//             coins-= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
//             shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
//             // update text
//             CoinsTxt.text = "Coins:"+coins.ToString();
//             // Update Quantity Text
//             ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
//         }
//     }
// }
