using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class ����1 : �����������
{
    private void Start()
    {
        transform.position = new Vector3(-6, 1, 0);
        NumberPlayer = 1; 
    }

    void Update()
    {
        inputControllerA = Input.GetKeyDown(KeyCode.Joystick1Button0);           //������ (A)  ��� ������� ������ ������ � �����
        inputControllerB = false;           //������ (B)  ������� ��������� ��� �������
        inputControllerY = false;           //������ (Y)  ������������� ��������
        inputControllerX = false;           //������ (X)  ����� � ����� ����������
        inputControllerRT = Input.GetAxis("LTRT1") > 0.4f  ? true : false;          //������ (RT) ������� �����
        floatControllerRT = 0;              ///���� ������ �� (RT) 
        inputControllerRB = Input.GetKeyDown(KeyCode.Joystick1Button5);          //������ (RB) ˨���� ����
        inputControllerLT = Input.GetAxis("LTRT1") < -0.4f ? true: false;              //������ (LT) ������ �����
        floatControllerLT = 0;              ///���� ������ �� (LT) 
        inputControllerLB = false;          //������ (LB) ����� � ��
        inputControllerDepadLeft = false;   //������ ������ �����
        inputControllerDepadRight = false;  //������ ������ ������
        inputControllerDepadTop = false;    //������ ������ �����
        inputControllerDepadButton = false; //������ ������ ����

        DvijenieVoin("1");
        Finish();
        Attak("1");
        StaminaUpdate();
        Fokys();
        

        Xmove = Input.GetAxis("Vertical" + NumberPlayer);//w � s, �������� ���� �������
        Ymove = Input.GetAxis("Horizontal" + NumberPlayer);//A � D, �������� ���� �������
        Timer.printlf("����� 1: �����/�����: " + Xmove + 
            "\n�����/������:               " + Ymove + 
            "\n�������: " + ((int)Stamina).ToString() + 
            " \nRx:"+Input.GetAxis("StikRHorizontal1").ToString() + 
            " \nRy:" + Input.GetAxis("StikRVertical1").ToString() );
    }

  //public new void DvijenieVoin() { }
   // public new void Attak() { }
}
