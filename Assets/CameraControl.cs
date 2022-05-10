using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Camera Cam;
    public ����1 ����1;
    public ����2 ����2;
    void Start()
    {
        Cam = GetComponent<Camera>();
    }

    void Update()
    {
        
        transform.position = new Vector3((����1.transform.position.x + ����2.transform.position.x)/2,0,-10);//���������� ������ �� ������ ����� ����� �������

        float Rasstoinie = Mathf.Abs(����1.transform.position.x - ����2.transform.position.x);//����� ���������� ���� �� ����� � ������
        if (Rasstoinie <15)//���� ��� ������� ������, �� ��������� ���������� ������
            Rasstoinie = 15;
        Cam.orthographicSize= (//�� � ���������� ������ ����������� ��� ��������� ������� ������
            Rasstoinie/5
            ) *16/9;
    }
}
