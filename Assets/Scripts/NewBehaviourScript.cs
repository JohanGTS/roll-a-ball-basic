using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad,tiempoRestante;
    private bool tiempoCorre;
    public TMP_Text timer, textoGanar;
    private int contador;

    public bool invertido=false ;

    private bool finJuego=false;
    public Text textoContador;

    void Start()
    {
        tiempoCorre = true;
        finJuego=false;
        rb = GetComponent<Rigidbody>();
        contador = 0;
        textoContador.text = "Contador: 0";
        textoGanar.text = "";

    }


    void DisplayTime(float tiempo)
    {
        tiempo++;
        float minutos = Mathf.FloorToInt(tiempo / 60);
        float segundos = Mathf.FloorToInt(tiempo % 60);
        timer.text = string.Format("{0:00} : {1:00}", minutos, segundos);
    }

    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ParedRotatoria"))
        {
            velocidad *=-1 ;
        }
    }

    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12 && tiempoCorre && !finJuego)
        {
            textoGanar.text = "¡Ganaste!";
            SaliendoDelJuego();
        }
        else if (!tiempoCorre&& !finJuego)
        {
            textoGanar.text = "¡Has perdido!";
            SaliendoDelJuego();
        }
    }

    private void SaliendoDelJuego()
    {
        velocidad=0;
        finJuego=true;
        Invoke("CargarEscenaPrincipal", 5f);
    }
    

    void CargarEscenaPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        rb.AddForce(movimiento * velocidad);

        if (tiempoCorre)
        {
            if (tiempoRestante >= 0)
            {
                tiempoRestante -= Time.deltaTime;
                DisplayTime(tiempoRestante);
            }
            else
            {
                tiempoCorre = false;
                setTextoContador();
                velocidad = 0;
            }
        }
    }
}
