using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class СтойкиШаблон : MonoBehaviour//Не правильно назвал, это шаблон для перемещения стоек за игроком
{
    public Шаблонвойна Воин;


 
    void Update()
    {
       
       transform.position = new Vector3(Воин.transform.position.x+(Воин.FokysAponentRight*0.5f), 0.6f, -0.1f);   
       
    }
   
}
