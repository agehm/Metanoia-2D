using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour
{
    // ---------------------------------------------------- [ Variaveis ) ----------------------
    // parte de aproximação e distanciamento
    [SerializeField]
    private float YOpened;
    [SerializeField]
    private float YClosed;
    [SerializeField]
    private float ZOpened;
    [SerializeField]
    private float ZClosed;

    [SerializeField]
    private float SpeedOfChange;

    private float V2;

    private float Vz;
    private float Vy;

    private bool OpenTheCamera;
    private bool CloseTheCamera;

    //controle geral do camera following

    public Camera Maincamera;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private Transform target;
    public Transform InicialTarget;

    private bool FreeCamera = true;


    [SerializeField]
    private bool AtivarOAbrirEFecharDaCamera = true;

    [SerializeField]
    private bool BlockedY = false;

    // ---------------- <<<<<<< (Limite - Camera antiga ) >>>>>>>>>>> --------------------

    [SerializeField]
    private Transform robot, limitRight, limitLeft;

    private Vector3 _innerPosition;


    // --------------------------------------- determinação da camera fechando e abrindo -------------------------------
    void Start()
    {
        target = InicialTarget;
        CloseTheCamera = false;
        OpenTheCamera = false;

        V2 = (ZOpened - ZClosed) / (YOpened - YClosed);

        BlockedY = false;

    }

    public void ChangeTarget(Transform NewTarget)
    {

        target = NewTarget;
    }

    public void ChangeCameraOpen(bool result)
    {

        OpenTheCamera = result;
        if (OpenTheCamera)
        {
            BlockedY = true;
        }
        else
        {
            BlockedY = false;
        }

    }

    public void ChangeCameraClose(bool result)
    {

        CloseTheCamera = result;

    }
    // ---------------------------------------  ------------------------------------ ----------------------------------




    // determina se a camera fica livre
    public void FreeTheCamera(bool SaleForFree)
    {
        FreeCamera = SaleForFree;
    }




    // Update is called once per frame
    void Update()
    {
        // ------------------- ((((((((     [ Parte que faz a camera seguir ))))))))))))) ----------------------
        if (FreeCamera == true)
        {
            if (target)
            {
                Vector3 point = Maincamera.WorldToViewportPoint(target.position);
                if(BlockedY)
                {
                    Vector3 delta = target.position - Maincamera.ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z)); //(new Vector3(0.5, 0.5, point.z));
                    Vector3 destination = transform.position + delta;
                    _innerPosition = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
                }
                else
                {
                                    Vector3 delta = target.position - Maincamera.ViewportToWorldPoint(new Vector3(0.5f, 0.32f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                    Vector3 destination = transform.position + delta;
                    _innerPosition = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
                }
            }



            if (_innerPosition.x < limitRight.position.x)
            {
                _innerPosition.x = limitRight.position.x;
            }

            if (_innerPosition.x > limitLeft.position.x)
            {
                _innerPosition.x = limitLeft.position.x;
            }

            transform.position = _innerPosition;
        }

        // --------------------------------------- determinação da camera fechando e abrindo -------------------------------


        if(AtivarOAbrirEFecharDaCamera)
        { 
        if (OpenTheCamera)
        {
                
            Vz = Maincamera.orthographicSize;
            Vz = Vz + ( V2 * SpeedOfChange * Time.deltaTime );
            Vy = transform.position.y;
            Vy += SpeedOfChange * Time.deltaTime;



            if (ZOpened > Maincamera.orthographicSize && YOpened > transform.position.y) //verificar se é menor ou maior
            {
                transform.position = new Vector3(transform.position.x, Vy, transform.position.z);//verificar sinal, positivo ou negativo
                    Maincamera.orthographicSize = Vz;
            }
            else
            {
                if (ZOpened > Maincamera.orthographicSize || YOpened > transform.position.y) //verificar se é menor ou maior
                {

                    if (ZOpened > Maincamera.orthographicSize)//verificar se é menor ou maior
                    {
                            Maincamera.orthographicSize = Vz;
                        }

                    if (YOpened > transform.position.y)//verificar se é menor ou maior
                    {
                        transform.position = new Vector3(transform.position.x, Vy, transform.position.z);//verificar sinal, positivo ou negativo
                    }

                }
                else
                {
                    OpenTheCamera = false;
                }
            }
        }





        if (CloseTheCamera)
        {
            Vz = Maincamera.orthographicSize;
            Vz -= V2 * SpeedOfChange * Time.deltaTime;
            Vy = transform.position.y;
            Vy -= SpeedOfChange * Time.deltaTime;

            if (ZClosed < Maincamera.orthographicSize && YClosed < transform.position.y) //verificar se é menor ou maior
            {
                    transform.position = new Vector3(transform.position.x, Vy, transform.position.z);//verificar sinal, positivo ou negativo
                    Maincamera.orthographicSize = Vz;
                }
            else
            {
                if (ZClosed < Maincamera.orthographicSize || YClosed < transform.position.y) //verificar se é menor ou maior
                {

                    if (ZClosed < Maincamera.orthographicSize)//verificar se é menor ou maior
                    {
                            Maincamera.orthographicSize = Vz;
                        }

                    if (YClosed < transform.position.y)//verificar se é menor ou maior
                    {
                        transform.position = new Vector3(transform.position.x, Vy, transform.position.z);//verificar sinal, positivo ou negativo
                    }

                }
                else
                {
                    CloseTheCamera = false;
                }
                }
            }
        }
    }
}

