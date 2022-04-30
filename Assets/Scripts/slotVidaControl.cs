using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotVidaControl : MonoBehaviour
{
    private GameObject PuntVida;

    public GameObject explosio;
    private bool vidaActiva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void inicialitza(GameObject vida) {
        PuntVida = vida;
        PuntVida.SetActive(true);
        vidaActiva = true;
    }

    public void hit() {
        PuntVida.SetActive(false);

        GameObject a = Instantiate(explosio, PuntVida.transform.position, Quaternion.identity);

        a.GetComponent<Animator>().enabled = true;
        a.SetActive(true);

        vidaActiva = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
