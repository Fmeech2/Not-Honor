using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class Шаблонвойна : MonoBehaviour
{
    public SpriteRenderer You;
    public bool _Proishodit_Dash = false;                      //тоже самое 0.700f
    public bool _Proishodit_NadejZachita = false;              //0.100f 0.166f
    public bool _Proishodit_Yklonenie = false;                 //0.100f 0.366f
    public bool _Proishodit_Stan = false;                      //
    public bool _Proishodit_DashNazad = false;
    public bool _Proishodit_DashNazad2=false;
    //Не трогай это, оно работает, значит уже хорошо. От методом тыка, сильно устаёшь.
    //Состояния деша: дешь в СТОРОНУ
    IEnumerator DashStadiiVBok(bool Right)
    {
        You = GetComponent<SpriteRenderer>();
        //Дешь в ПРАВО?
        if (Right)
        {
            //Деш в бок, в сторону к нам
            if (FokysAponentRight > 0)
            {
                transform.position += new Vector3(0, (RazmerVoinaY * 1.1f - RazmerVoinaY) / 2, -1);
                this.transform.localScale = new Vector3(RazmerVoinaX * 1.1f, RazmerVoinaY * 1.1f, RazmerVoinaZ * 1.1f);
            }
            //Деш в бок, в сторону от нас
            else
            {
                transform.position += new Vector3(0, (RazmerVoinaY / 1.1f - RazmerVoinaY) / 2, 1);
                this.transform.localScale = new Vector3(RazmerVoinaX / 1.1f, RazmerVoinaY / 1.1f, RazmerVoinaZ / 1.1f);
            }
        }
        //Дешь в ЛЕВО
        else
        {
            //Деш в бок, в сторону от нас
            if (FokysAponentRight > 0)
            {
                transform.position += new Vector3(0, (RazmerVoinaY / 1.1f - RazmerVoinaY) / 2, 1);
                this.transform.localScale = new Vector3(RazmerVoinaX / 1.1f, RazmerVoinaY / 1.1f, RazmerVoinaZ / 1.1f);
            }
            //Деш в бок, в сторону к нам
            else
            {
                transform.position += new Vector3(0, (RazmerVoinaY * 1.1f - RazmerVoinaY) / 2, -1);
                this.transform.localScale = new Vector3(RazmerVoinaX * 1.1f, RazmerVoinaY * 1.1f, RazmerVoinaZ * 1.1f);
            }
        }
        _Proishodit_Dash = true;
        You.color = new Color(0.9f, 1f, 1f, You.color.a);
        yield return new WaitForSeconds(0.100f);
        _Proishodit_NadejZachita = true;
        yield return new WaitForSeconds(0.066f);
        _Proishodit_NadejZachita = false;
        _Proishodit_Yklonenie = true;
        yield return new WaitForSeconds(0.200f);
        _Proishodit_Yklonenie = false;
        You.color = new Color(1f, 1f, 1f, You.color.a);
        yield return new WaitForSeconds(0.333f);
        _Proishodit_Dash = false;
        //Возвращаем координаты персонажа в норму
        transform.position = new Vector3(transform.position.x, 1, 0);
        //Возвращаем размеры персонажа в норму
        this.transform.localScale = new Vector3(RazmerVoinaX, RazmerVoinaY, RazmerVoinaZ);
        //меняем местами персонажей после ближнего деша
        if (DeshVplotnyuSlychilsa)
        {
            EnemyPlayer.transform.position = new Vector3(pozitionMy, transform.position.y, 0);
            transform.position = new Vector3(pozitionAponent, transform.position.y, 0);
        }
    }
    //Состояния деша: дешь ВПЕРЁД
    IEnumerator DashStadiiVPered()
    {
        You = GetComponent<SpriteRenderer>();
        _Proishodit_Dash = true;
        You.color = new Color(0.9f, 1f, 1f, You.color.a);
        yield return new WaitForSeconds(0.100f);
        _Proishodit_NadejZachita = true;
        yield return new WaitForSeconds(0.266f);
        _Proishodit_NadejZachita = false;
        You.color = new Color(1f, 1f, 1f, You.color.a);
        yield return new WaitForSeconds(0.333f);
        _Proishodit_Dash = false;
    }
    //Состояния деша: дешь НАЗАД
    IEnumerator DashStadiiNazad()
    {
        if (TimerDablDush == 0)
        {
            TimerDablDush=Time.time+0.666f;
        }
        else if(TimerDablDush>Time.time)
        {
            _Proishodit_DashNazad2=true;
        }
        _Proishodit_DashNazad=true;
        You = GetComponent<SpriteRenderer>();
        _Proishodit_Dash = true;
        You.color = new Color(0.9f, 1f, 1f, You.color.a);


        yield return new WaitForSeconds(0.100f);      
        _Proishodit_Yklonenie = true;


        yield return new WaitForSeconds(0.266f);
        _Proishodit_Yklonenie = false;       
        You.color = new Color(1f, 1f, 1f, You.color.a);


        yield return new WaitForSeconds(0.333f);

        if (TimerDablDush<Time.time)
        {
            TimerDablDush = 0;
            _Proishodit_Dash = false;
            _Proishodit_DashNazad = false;
            _Proishodit_DashNazad2 = false;
        }

    }
    protected float TimerDablDush = 0;

    //Все коментарии поясняют код ниже себя или левее, относительно самого коментария (например этот коментарий поясняет коментарии к коду находящемуся ниже этого коментария)
    public Шаблонвойна EnemyPlayer; 
    public DPS dpsStick;            //текстовые экземлыры для временного UI
    public DPS WinStatys;           //текстовые экземлыры для временного UI
    public DPS Timer;               //текстовые экземлыры для временного UI
    public int NumberPlayer;     
    public float Health = 125;      
    public float Stamina = 120;     
    public float StaminaMax = 120;  
    public bool StaminaFull = true;     //Стамина полная?
    public bool StaminaZdohla = false;  //Персонаж выдыхся?
    public int Stoika = 3;   
    private float timerStoika = 0;
    public float DalnostAtaki = 4;                      //Дальность атаки не в комбо ударах
    public float speead { get { return 2.12f * 5; } }   //5 это модификатор скорости для коректного отображения в игре(не трогать 5), 2.12 это скорость м/c взятые из википедии
    public bool _Proishodit_GiperBron = false;          //состояние персонажа(например правдали ли сейчас персонаж под ГиперБронёй)
    public bool _Proishodit_AtakyetHevi = false;        //тоже самое
    public bool _Proishodit_AtakyetLite = false;        //тоже самое
    public bool _Proishodit_Krovotok = false;           //тоже самое
    public bool _Proishodit_DashVPERED = false;  
    public int _Stoika { get { return _Stoika; } set { if (value < 1 || 3 < value) _Stoika = 1; else _Stoika = value; } }
    public float HitboxX { get { return 2; } }
    public float HitboxY { get { return 4; } }
    private float RazmerVoinaX = 10;
    private float RazmerVoinaY = 6;
    private float RazmerVoinaZ = 1;
    private float KenseyNachHitBoxY;
    private float KenseyNachHitBoxX;
    private float KenseyNachPositionY;
    private float KenseyNachPositionX;
    private bool NapravlenieRight = true;
    private float dash = 0f;             //стартовый деш. Соответствнно в начале мы не дешимся
    private float timerDash = 0;         //Время заморозки передвижения персонажа на время деша
    private float dashNazadOrVpered = 40;//Сила деша вперёд или назад
    private float dashVBok = 90;         //Эмуляция деша в бок, по средствам задания большой силы деша вперёд

    //Я не знаю почему, но существует мистический дешь в бок если противники находятся далеко друг от друга.
    //И он почему то ультра маленький, даже если выставлять скорость деша невероятно большой.
    //Я запарился уже искать в чём здесь ошибка, так что я просто оставил этот мистический кусоск кода
    //И выкрутил в нём ползунки на максимум. Чиним костыли - костылями. Нормально делай - нормально будет.
    //ВНИМАНИЕ: Я ПОЧИНИЛ ОШИБКУ. Оказывается н етолько в VC надо учитывать что код скомпелируется некорректно,
    //но и в Unity. Пол дня были потрачены, на решение проблемы которая просто требовала перезапуск Unity.
    //Конечно может во всём этот по прежднему был виноват VC, но теперь даже юнити придётся учитывать тот фактор,
    //что твои ошибки могут быть и не твоими ошибками вовсе. https://sun9-85.userapi.com/s/v1/if2/sE3IktEwKBKkyX9iNIP4poAe00ysaqhdAxLyffjFXwHN5BOAeSGhM9p9msMVjCRWqDg2XIq1Bu_L0cUmLkucmiAi.jpg?size=1920x1535&quality=95&type=album
    //Только что узнал ещё одну тонкость работы с юнити. Все переменные записанные в классе, а не в методе старта
    //не будут сохраняться если у тебя включен отладчик в юнити. Юнити сначала надо остановить, и ТОЛЬКО потом
    //сохранять с# код, что бы изменения в полях класса сохранились. Походу юнити хранит все публичные переменые 
    //в своей локальной памяти, для последующей визуализации их в проекте. И если вдруг он видит, что код не изменился,
    //а во время работы юнити при обновлении кода, поля класса в любом случае не поменяются((
    //тем самым он думает что у него последняя актуальная информация, и раз за разом он выдаёт тебе старые данные
    //пока ты его не перезагрузишь или не обновишь код, кода юнити остановлен.
    private float dashDalekoVBok = 30f;  //Эмуляция деша в бок, если противник находися далеко
    public float FokysAponentRight = 1;
    public float Bezdeistvie = 0;
    public float HeviAtakaZavershitsa = 0;
    public float HeviAtakaOtmena = 0;
    public float LiteAtakaZavershitsa = 0;
    public float PeredishkaPosleAtaki = 0;
    public float FokysAponentRightGLOBAL = 1;
    public float pozitionAponent = 0;
    public float pozitionMy = 0;
    public bool DeshVplotnyuSlychilsa = false;
    public float RasstoinieMejVoinami = 4;
    /*
     Переменные ниже - указатели на кнопки управления геймпада
    */

    public bool inputControllerA = false;           //Кнопка (A)  или обычная кнопка прыжка в играх
    public bool inputControllerB = false;           //Кнопка (B)  быстрые сообщения для команды
    public bool inputControllerY = false;           //Кнопка (Y)  Воспроизвести анимацию
    public bool inputControllerX = false;           //Кнопка (X)  взять в фокус противника
    public bool inputControllerRT = false;          //Кнопка (RT) ТЯЖЕЛАЯ АТАКА
    public float floatControllerRT = 0;             ///Сила нажима на (RT) //RT>0
    public bool inputControllerRB = false;          //Кнопка (RB) ЛЁГКАЯ АТАК
    public bool inputControllerLT = false;          //Кнопка (LT) Отмена атаки
    public float floatControllerLT = 0;             ///Сила нажима на (LT) //LT<0 
    public bool inputControllerLB = false;          //Кнопка (LB) Взять в ГБ
    public bool inputControllerDepadLeft = false;   //Кнопка депада влево
    public bool inputControllerDepadRight = false;  //Кнопка депада вправо
    public bool inputControllerDepadTop = false;    //Кнопка депада вверх
    public bool inputControllerDepadButton = false; //Кнопка депада вниз
    public float Xmove = 0;                         //Кнопку нет нужды переопределять, в коде она используется по нумератору игрока
    public float Ymove = 0;                         //Кнопку нет нужды переопределять, в коде она используется по нумератору игрока
    public float inputControllerRStickX = 0;        //Кнопку нет нужды переопределять, в коде она используется по нумератору игрока
    public float inputControllerRStickY = 0;        //Кнопку нет нужды переопределять, в коде она используется по нумератору игрока
    //Запуск вызывается перед первым обновлением первого кадра
    void Start()
    {
        KenseyNachPositionY = transform.position.y;
        KenseyNachHitBoxX = transform.position.x;
        KenseyNachHitBoxY = transform.localScale.y / 2f;
        KenseyNachPositionX = transform.localScale.x / 2;
    }
    //Обновление вызывается один раз за кадр
    void Update()
    {      
         Finish();
     
        //StaminaUpdate(); //Я не понимаю как работает Полиморфизм в Update
        float Xmouse = Input.GetAxis("Mouse X");//Мышка X
        float Ymouse = Input.GetAxis("Mouse Y");//Мышка Y
    }
    //Передвижение персонажа
    public void DvijenieVoin(string NumberPlayer)
    {
        Xmove = Input.GetAxis("Vertical"+NumberPlayer);//w и s, возможно даже геймпад
        Ymove = Input.GetAxis("Horizontal"+ NumberPlayer);//A и D, возможно даже геймпад
        dpsStick.printlf(Xmove.ToString());
        Dash(Xmove, Ymove);

        /*ненужная фигня, но я столько времени прописывал гравитацию обьектам собственную, так что не буду удалять(в фороноре нет прыжка DDD)*/
        /*ненужная фигня,но это трогать ещё страшнее чем предыдущее*/
        //Всё таки мне пришлось подчистить код и удалить ненужные старые части игры, раньше здесь была такая крута реализация гравитации.
        //А теперь этот код отвечат просто за движение игрока
        transform.position = new Vector3(transform.position.x+(FokysAponentRight * (dash * Time.deltaTime + Xmove * speead * Time.deltaTime)), transform.position.y, 0);  
     
        //Игроки слишком близко друг другу. противаоввес не даёт им приближаться дальше друг к другу
        if (Mathf.Abs(this.transform.position.x - EnemyPlayer.transform.position.x) < RasstoinieMejVoinami && Xmove > 0)
        {
            transform.position -= new Vector3(FokysAponentRight * (dash * Time.deltaTime + Xmove * speead * Time.deltaTime), 0, 0);
        }
        //Игроки слишком близко друг другу. противаоввес ДЕШУ не даёт ДЕШАИТЬСЯ вперёд
        else if (Mathf.Abs(this.transform.position.x - EnemyPlayer.transform.position.x) < RasstoinieMejVoinami && _Proishodit_DashVPERED&& !(Xmove<-0.1f))
        {
            transform.position -= new Vector3(FokysAponentRight * (dash * Time.deltaTime + Xmove * speead * Time.deltaTime), 0, 0);
        }
        if (transform.position.x > 30)
        {
            transform.position = new Vector3(30, 1, 0);
        }
        if (transform.position.x < -30)
        {
            transform.position = new Vector3(-30, 1, 0);
        }

    }
    public void Finish()//временный метод для отображения хп. Метод затычка.
    {
        if (Health <= 0)
            WinStatys.printlf("Проиграл: Жизней(" + Health.ToString() + ")");
        else WinStatys.printlf(Health.ToString());
    }
    //задержка перед сменой стоки в 100мс
    //лучше для этих целей использовать Invoke или StartCoroutine
    public void Attak(string NumberPlayer)//ОСТОРОЖНО: в методе используются аналогичный код для управления двумя разными игрокоми.
                                          //Есть вероятность что любые изменения в коде необходимо будет дублировать для второго игрока.
    {
        //СТОЙКИ
        {
            //Задержка для смены стойки
            IEnumerator StoikaStadii(int stoika)
            {
                if (!_Proishodit_Stan)
                {
                    this.Stoika = stoika;
                    yield return new WaitForSeconds(0.100f);
                }
            }
            //Смена стойки
            if (Input.GetAxis("StikRVertical" + NumberPlayer) < -0.60)
            {
                StartCoroutine(StoikaStadii(2));
            }
            else if (Input.GetAxis("StikRHorizontal" + NumberPlayer) < -0.60)
            {
                StartCoroutine(StoikaStadii(1));
            }
            else if (Input.GetAxis("StikRHorizontal" + NumberPlayer) > 0.60)
            {
                StartCoroutine(StoikaStadii(3));
            }
        }
        
        //Запрет востанавливать стамину во время проведения ударов
        if (_Proishodit_AtakyetLite || _Proishodit_AtakyetHevi)
        {
            Stamina -= 15f * Time.deltaTime;
        }
        //лёгкая атака ПЕРВОГО ИГРОКА
        if (inputControllerRB && PeredishkaPosleAtaki < Time.time)
        {
            if (Time.time > Bezdeistvie)
            {
                _Proishodit_AtakyetLite = true;
                Bezdeistvie = 0.500f + Time.time;
                Stamina -= 9;
                if (StaminaZdohla)
                {
                    LiteAtakaZavershitsa = 0.800f + Time.time;
                }
                else
                {
                    LiteAtakaZavershitsa = 0.500f + Time.time;
                }
            }
        }
        //добавление информации о нажатии кнопки отмены ИГРОКА
        if (inputControllerLT && HeviAtakaZavershitsa - Time.time > 0.200)
        {
            HeviAtakaOtmena = HeviAtakaZavershitsa - 0.200f;
        }

        //Полсекунды прошло и атака лайт нанесла урон
        if (LiteAtakaZavershitsa != 0 && Time.time > LiteAtakaZavershitsa)
        {
            LiteAtakaZavershitsa = 0;
            if (Stoika == EnemyPlayer.Stoika)
            {
                EnemyPlayer.Health -= 0;
            }
            else
            {
            EnemyPlayer.Health -= 12;
            }
            _Proishodit_AtakyetLite = false;
            PeredishkaPosleAtaki = 0.200f + Time.time;
        }



        //Полсекунды прошло и атака хеви нанесла урон
        if (HeviAtakaZavershitsa != 0 && Time.time > HeviAtakaZavershitsa)
        {
            HeviAtakaZavershitsa = 0;
            if (Stoika == EnemyPlayer.Stoika)
            {
                EnemyPlayer.Health -= 5;
            }
            else
            {
                EnemyPlayer.Health -= 27;
            }
            _Proishodit_AtakyetHevi = false;
            PeredishkaPosleAtaki = 0.200f + Time.time;
        }
        //проверка: нажималась ли кнопка отммены тяжёлой атаки
        if (HeviAtakaOtmena != 0 && Time.time > HeviAtakaOtmena)
        {
            HeviAtakaOtmena = 0;
            Bezdeistvie = 0;
            HeviAtakaZavershitsa = 0;
            _Proishodit_AtakyetHevi = false;
        }
        //ТЯЖЁЛАЯ атака //LT<0 //RT>0
        if (inputControllerLT && PeredishkaPosleAtaki < Time.time)
        {
            HeavyАttack?.Invoke();
        }
        EnemyPlayer.HeavyАttack += метод;
        void метод()
        {
            if (Time.time > Bezdeistvie)
            {
                _Proishodit_AtakyetHevi = true;
                Bezdeistvie = 0.800f + Time.time;
                Stamina -= 12;
                if (StaminaZdohla)
                {
                    HeviAtakaZavershitsa = 1.100f + Time.time;
                }
                else
                {
                    HeviAtakaZavershitsa = 0.800f + Time.time;
                }

            }
        }
        
    }
    public delegate void AttackDelegate();
    public event AttackDelegate HeavyАttack;
    public void Dash(float Xmove, float Ymove)
    {                                         
        //определяем направление для деша
        if (Xmove > 0)
            NapravlenieRight = true;
        else if (Xmove < 0)
            NapravlenieRight = false;
        //убавление скорости деша
        if (dash > 0)
        {
            dash -= 1f;
        }
        else if (dash < 0)
        {
            dash += 1f;  
        }
        //эффектно останавливаем резко деш пи достижении определённой скорости *Анимация*
        if ((-10 < dash && dash < 10) && dash != 0)
        {
            dash = 0;
       
        }
        //Блокируем передвижение во время деша
        else if (timerDash > Time.time)
        {
            this.Xmove = this.Xmove/10;  
        }

        //Деш нажали - значит деш запустили                                                         
        if (inputControllerA)
        {
            //проверяем не в стане ли сейчас игрок
            if (!_Proishodit_Stan)
            {
                //игрок хочет оббежжать противника дешом в ЛЕВО? в противном случае в право или просто деш назад или вперёд по направлению стика
                if (Ymove < -0.5)
                {
                    //проверяем не делает ли сейчас игнрок деш
                    if (!_Proishodit_Dash)
                    {
                        StartCoroutine(DashStadiiVBok(false));
                        if (Mathf.Abs(this.transform.position.x - EnemyPlayer.transform.position.x) > RasstoinieMejVoinami + .3)//Вычисляем расстояние игроков друг от друга
                        {
                            dash = dashDalekoVBok;//Деш в бок если игроки далеко друг от друга
                            DeshVplotnyuSlychilsa = false;
                        }
                        else
                        {
                            dash = dashVBok;//Деш вокруг противника - деш в бок
                            pozitionAponent = EnemyPlayer.transform.position.x;
                            pozitionMy = this.transform.position.x;
                            DeshVplotnyuSlychilsa = true;
                        }
                        _Proishodit_DashVPERED = false;
                    }
                }
                //игрок хочет оббежжать противника дешом в ПРАВО? в противном случае просто деш назад или вперёд по направлению стика
                else if (0.5 < Ymove)
                {
                    //проверяем не делает ли сейчас игнрок деш
                    if (!_Proishodit_Dash)
                    {
                        StartCoroutine(DashStadiiVBok(true));
                        if (Mathf.Abs(this.transform.position.x - EnemyPlayer.transform.position.x) > RasstoinieMejVoinami + .3)//Вычисляем расстояние игроков друг от друга
                        {
                            dash = dashDalekoVBok;//Деш в бок если игроки далеко друг от друга
                            DeshVplotnyuSlychilsa = false;
                        }
                        else
                        {
                            dash = dashVBok;//Деш вокруг противника - деш в бок
                            pozitionAponent = EnemyPlayer.transform.position.x;
                            pozitionMy = this.transform.position.x;
                            DeshVplotnyuSlychilsa = true;
                        }
                        _Proishodit_DashVPERED = false;
                    }
                }
                //просто деш назад или вперёд по направлению стика
                else
                {
                    DeshVplotnyuSlychilsa = false;
                    _Proishodit_DashVPERED = true;
                    //Дешь НАЗАД
                    if (Xmove == 0 || !NapravlenieRight)//Я не помню зачем я спрашиваю "Направление", но надо, значит надо. Главное что работает верно
                    {
                        //проверяем не делает ли сейчас игрок деш
                        if (_Proishodit_Dash)
                        {
                            //ДВОЙНОЙ ДЕШЬ назад
                            if (_Proishodit_DashNazad)
                            {
                                if (!_Proishodit_DashNazad2)
                                {
                                    if (!StaminaZdohla)
                                    {
                                        StartCoroutine(DashStadiiNazad());
                                        Stamina -= 50;               //стамина тратится при перекате или ударе в увороте                                                                  
                                        dash = -dashNazadOrVpered * 1.5f;  //По итогу дешь назад умножается на FokysAponentRight тем самым выбирая направление по 2d оси правильно
                                    }
                                }
                            }
                        }
                        else
                        {
                            StartCoroutine(DashStadiiNazad());
                            Stamina -= 0;               //стамина тратится только при перекате или ударе в увороте   
                                                        //оставил этот бесполезный код как напоминание на будующее 
                            dash = -dashNazadOrVpered;  //По итогу дешь назад умножается на FokysAponentRight тем самым выбирая направление по 2d оси правильно
                        }
                    }
                    //Дешь ВПЕРЁД
                    else
                    {
                        //проверяем не делает ли сейчас игнрок деш
                        if (!_Proishodit_Dash)
                        {
                            StartCoroutine(DashStadiiVPered());
                            dash = dashNazadOrVpered;   //По итогу дешь вперёд умножается на FokysAponentRight тем самым выбирая направление по 2d оси правильно
                            Stamina -= 0;               //что надо добавить убавление стамины при перекате и ударе в увороте                            
                        }
                    }
                }
                timerDash = 0.700f + Time.time;
            }
        }
    }
    public void Animeit() { }
    public void Fokys() 
    {

        if (this.transform.position.x < EnemyPlayer.transform.position.x)
        {
            FokysAponentRight = 1;
        }
        else
        {
            FokysAponentRight = -1;
        }

        
    }
    public void StaminaUpdate()
    {
        if (Stamina < StaminaMax)//Восполнение стамины
        {
            Stamina += 15f * Time.deltaTime;

        }    
        else                    //Стамина востановилась полностью
        {
            StaminaFull = true;
            StaminaZdohla = false;
        }
        if (Stamina < 0)   //персонаж выдыхся
        {
            Stamina = 0;
            StaminaZdohla = true;
        }
        if (_Proishodit_DashNazad)//запрет на восстановление стамины во время деша назад
        {
            Stamina -= 15f * Time.deltaTime;
        }

    }


   

}


  
