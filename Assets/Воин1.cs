using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Воин1 : Шаблонвойна
{
    private void Start()
    {
        transform.position = new Vector3(-6, 1, 0);
        NumberPlayer = 1; 
    }

    void Update()
    {
        inputControllerA = Input.GetKeyDown(KeyCode.Joystick1Button0);           //Кнопка (A)  или обычная кнопка прыжка в играх
        inputControllerB = false;           //Кнопка (B)  быстрые сообщения для команды
        inputControllerY = false;           //Кнопка (Y)  Воспроизвести анимацию
        inputControllerX = false;           //Кнопка (X)  взять в фокус противника
        inputControllerRT = Input.GetAxis("LTRT1") > 0.4f  ? true : false;          //Кнопка (RT) ТЯЖЕЛАЯ АТАКА
        floatControllerRT = 0;              ///Сила нажима на (RT) 
        inputControllerRB = Input.GetKeyDown(KeyCode.Joystick1Button5);          //Кнопка (RB) ЛЁГКАЯ АТАК
        inputControllerLT = Input.GetAxis("LTRT1") < -0.4f ? true: false;              //Кнопка (LT) Отмена атаки
        floatControllerLT = 0;              ///Сила нажима на (LT) 
        inputControllerLB = false;          //Кнопка (LB) Взять в ГБ
        inputControllerDepadLeft = false;   //Кнопка депада влево
        inputControllerDepadRight = false;  //Кнопка депада вправо
        inputControllerDepadTop = false;    //Кнопка депада вверх
        inputControllerDepadButton = false; //Кнопка депада вниз

        DvijenieVoin("1");
        Finish();
        Attak("1");
        StaminaUpdate();
        Fokys();
        

        Xmove = Input.GetAxis("Vertical" + NumberPlayer);//w и s, возможно даже геймпад
        Ymove = Input.GetAxis("Horizontal" + NumberPlayer);//A и D, возможно даже геймпад
        Timer.printlf("Игрок 1: Вперёд/назад: " + Xmove + 
            "\nВлево/вправо:               " + Ymove + 
            "\nСтамина: " + ((int)Stamina).ToString() + 
            " \nRx:"+Input.GetAxis("StikRHorizontal1").ToString() + 
            " \nRy:" + Input.GetAxis("StikRVertical1").ToString() );
    }

  //public new void DvijenieVoin() { }
   // public new void Attak() { }
}
