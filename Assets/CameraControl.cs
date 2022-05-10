using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera Cam;
    public Воин1 Воин1;
    public Воин2 Воин2;
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    void Update()
    {
        
        transform.position = new Vector3((Воин1.transform.position.x + Воин2.transform.position.x)/2,0,-10);//перемещаем камеру по центру между двумя войнами

        float Rasstoinie = Mathf.Abs(Воин1.transform.position.x - Воин2.transform.position.x);//Узнаём расстояние друг от друга у войнов
        if (Rasstoinie <15)//если они слишком близко, то блокируем уменьшение камеры
            Rasstoinie = 15;
        Cam.orthographicSize= (//ну и собственно говоря увеличиваем или уменьшаем размеры камеры
            Rasstoinie/5
            ) *16/9;
    }
}
