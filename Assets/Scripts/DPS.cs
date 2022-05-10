using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DPS : MonoBehaviour
{
    [SerializeField] private Text dps;
    public void printlf(string a)
    {        
        dps.text = a;      
    }
   

}
