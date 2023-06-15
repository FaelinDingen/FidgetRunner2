using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandeler : MonoBehaviour
{
    static public int fidgets;
    static public bool gyroEnabled = true;  //might need to get rid of  = true in the futre and just add an if statment in start in player script that checks if it is null then it is true
    static public bool acceleromiterEnabled = false; //same as here^
    static public Material usingMaterial;
    static public bool bearingSkinned;
    static public int hightScore = 0;


    //make bought skins data
    static public bool[] ownedSkins = new bool[] {true, false, false, false, false, false };
}
