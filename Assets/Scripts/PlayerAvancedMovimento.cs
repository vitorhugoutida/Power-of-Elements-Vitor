using UnityEngine;

public class PlayerAvancedMovimento : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidadeNormal = 5f;
    public float velocidadeSprint = 10f;
    private float velocidadeAtual;

    [Header("Pulo")]
    public float forcaDoPulo = 14f;
    public Transform checarChao;
    public float raioDoChao = 0.2f;
    public LayerMask camadaDoChao;
    private bool isGrounded;

    [Header("Pulo Duplo")]
    public int pulosMaximos = 1;
    private int pulosRestantes = 1;
    private bool estavaNoChaoAntes;



    [Header("Sprint")]
    public float tempoSprint = 3f;
    public float tempoRecargaSprint = 3f;
    private float timerSprint = 0f;
    private float timerRecarga = 0f;
    private bool podeCorrer = false;
    private bool estaCorrendo = false;
    private bool sprintDesbloqueado = false;

    [Header("Camera")]
    public Camera cameraPrincipal;
    public float fovNormal = 90f;
    public float fovSprint = 120f;
    public float velocidadeFov = 5f;

    private Rigidbody rb;
    private Vector3 movimento;



    //void Start()
    //{
    //        pulosMaximos = 1;
    //        pulosRestantes = pulosMaximos;
    //        rb = GetComponent<Rigidbody>();


    //    rb = GetComponent<Rigidbody>();
    //    velocidadeAtual = velocidadeNormal;

    //    if (cameraPrincipal == null)
    //    {
    //        cameraPrincipal = Camera.main;
    //    }
    //}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidadeAtual = velocidadeNormal;

        if (cameraPrincipal == null)
        {
            cameraPrincipal = Camera.main;
        }

        pulosMaximos = 1;
        pulosRestantes = pulosMaximos;
    }


    //void Update()
    //{
    //    // Ve se está tocado no chao
    //    isGrounded = Physics.CheckSphere(checarChao.position, raioDoChao, camadaDoChao);




    //    //if (Input.GetButtonDown("Jump") && isGrounded)
    //    //{
    //    //    rb.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
    //    //}

    //    if (isGrounded)
    //    {
    //        pulosRestantes = pulosMaximos;
    //    }

    //    if (Input.GetButtonDown("Jump") && pulosRestantes > 0)
    //    {
    //        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
    //        rb.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
    //        pulosRestantes--;
    //    }

    //    // Input de movimento
    //    float moveX = Input.GetAxis("Horizontal");
    //    float moveZ = Input.GetAxis("Vertical");
    //    movimento = new Vector3(moveX, 0, moveZ).normalized;

    //    if (sprintDesbloqueado)
    //    {
    //        // Quando Shift for pressionado e o jogador pode correr
    //        if (Input.GetKey(KeyCode.LeftShift) && podeCorrer && movimento.magnitude > 0.1f)
    //        {
    //            estaCorrendo = true;
    //            velocidadeAtual = velocidadeSprint;
    //            timerSprint += Time.deltaTime;

    //            if (timerSprint >= tempoSprint)
    //            {
    //                podeCorrer = false;
    //                timerRecarga = 0f;
    //                estaCorrendo = false;
    //            }
    //        }
    //        else
    //        {
    //            estaCorrendo = false;
    //            velocidadeAtual = velocidadeNormal;

    //            if (!podeCorrer)
    //            {
    //                timerRecarga += Time.deltaTime;
    //                if (timerRecarga >= tempoRecargaSprint)
    //                {
    //                    podeCorrer = true;
    //                    timerSprint = 0f;
    //                }
    //            }
    //        }

    //        // FOV 90 > 120
    //        float fovAlvo = estaCorrendo ? fovSprint : fovNormal;
    //        cameraPrincipal.fieldOfView = Mathf.Lerp(cameraPrincipal.fieldOfView, fovAlvo, Time.deltaTime * velocidadeFov);
    //    }

    //}

    void Update()
    {
        isGrounded = Physics.CheckSphere(checarChao.position, raioDoChao, camadaDoChao);

        if (isGrounded && !estavaNoChaoAntes)
        {
            pulosRestantes = pulosMaximos;
        }

        estavaNoChaoAntes = isGrounded;

        if (Input.GetButtonDown("Jump") && pulosRestantes > 0)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // zera Y pra pulo limpo
            rb.AddForce(Vector3.up * forcaDoPulo, ForceMode.Impulse);
            pulosRestantes--;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movimento = new Vector3(moveX, 0, moveZ).normalized;

        if (sprintDesbloqueado)
        {
            if (Input.GetKey(KeyCode.LeftShift) && podeCorrer && movimento.magnitude > 0.1f)
            {
                estaCorrendo = true;
                velocidadeAtual = velocidadeSprint;
                timerSprint += Time.deltaTime;

                if (timerSprint >= tempoSprint)
                {
                    podeCorrer = false;
                    timerRecarga = 0f;
                    estaCorrendo = false;
                }
            }
            else
            {
                estaCorrendo = false;
                velocidadeAtual = velocidadeNormal;

                if (!podeCorrer)
                {
                    timerRecarga += Time.deltaTime;
                    if (timerRecarga >= tempoRecargaSprint)
                    {
                        podeCorrer = true;
                        timerSprint = 0f;
                    }
                }
            }

            // FOV 90 -> 120
            float fovAlvo = estaCorrendo ? fovSprint : fovNormal;
            cameraPrincipal.fieldOfView = Mathf.Lerp(cameraPrincipal.fieldOfView, fovAlvo, Time.deltaTime * velocidadeFov);
        }
    }


    public void AtivarSprint()
    {
        sprintDesbloqueado = true;
        podeCorrer = true;
    }

    public void AtivarPuloDuplo()
    {
        pulosMaximos = 2;
    }



    void FixedUpdate()
    {
        Vector3 direcao = transform.TransformDirection(movimento) * velocidadeAtual;
        Vector3 velocidadeDesejada = new Vector3(direcao.x, rb.linearVelocity.y, direcao.z);
        rb.linearVelocity = velocidadeDesejada;
    }
}
