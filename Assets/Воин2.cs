using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ����2 : �����������
{
    private void Start()
    {
        transform.position= new Vector3(6,1, 0);
        NumberPlayer = 2;
    }
    void Update()
    {
        inputControllerA = Input.GetKeyDown(KeyCode.Joystick2Button0);           //������ (A)  ��� ������� ������ ������ � �����
        inputControllerB = false;           //������ (B)  ������� ��������� ��� �������
        inputControllerY = false;           //������ (Y)  ������������� ��������
        inputControllerX = false;           //������ (X)  ����� � ����� ����������
        inputControllerRT = Input.GetAxis("LTRT2") > 0.4f ? true : false;          //������ (RT) ������� �����
        floatControllerRT = 0;              ///���� ������ �� (RT) 
        inputControllerRB = Input.GetKeyDown(KeyCode.Joystick1Button5);          //������ (RB) ˨���� ����
        inputControllerLT = Input.GetAxis("LTRT2") < -0.4f ? true : false;              //������ (LT) ������ �����
        floatControllerLT = 0;              ///���� ������ �� (LT) 
        inputControllerLB = false;          //������ (LB) ����� � ��
        inputControllerDepadLeft = false;   //������ ������ �����
        inputControllerDepadRight = false;  //������ ������ ������
        inputControllerDepadTop = false;    //������ ������ �����
        inputControllerDepadButton = false; //������ ������ ����

        DvijenieVoin("2");
        Finish();
        Attak("2");
        StaminaUpdate();
        Fokys();

        Xmove = Input.GetAxis("Vertical" + NumberPlayer);//w � s, �������� ���� �������
        Ymove = Input.GetAxis("Horizontal" + NumberPlayer);//A � D, �������� ���� �������
        Timer.printlf("����� 2: �����/�����: " + Xmove + "\n�����/������:               " + Ymove + "\n�������: " + ((int)Stamina).ToString() + " \nRx:" + Input.GetAxis("StikRHorizontal2").ToString() + " \nRy:" + Input.GetAxis("StikRVertical2").ToString());
    }
   

}
