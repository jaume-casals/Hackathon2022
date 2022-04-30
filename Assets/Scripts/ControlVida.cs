using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlVida : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public GameObject OGVida;

    int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
        Vector3 posSlot1 = slot1.transform.position;
        GameObject vida1 = Instantiate(OGVida, posSlot1, Quaternion.identity);
        slot1.GetComponent<slotVidaControl>().inicialitza(vida1);

        Vector3 posSlot2 = slot2.transform.position;
        posSlot2.x += 0.05f;
        GameObject vida2 = Instantiate(OGVida, posSlot2, Quaternion.identity);
        slot2.GetComponent<slotVidaControl>().inicialitza(vida2);

        Vector3 posSlot3 = slot3.transform.position;
        posSlot3.x += 0.04f;
        GameObject vida3 = Instantiate(OGVida, posSlot3, Quaternion.identity);
        slot3.GetComponent<slotVidaControl>().inicialitza(vida3);
    }

    private IEnumerator GameOver() {
        print("GAME OVER");
        yield return new WaitForSeconds(2);
        GameOverText.GetComponent<Text>().text = "Game Over!";
        GameOverText.SetActive(true);
        Time.timeScale = 0;
    }

    public void baixaVida() {
        if (vida == 3) slot3.GetComponent<slotVidaControl>().hit();
        else if (vida == 2) slot2.GetComponent<slotVidaControl>().hit();
        else {
            slot1.GetComponent<slotVidaControl>().hit();
            StartCoroutine(GameOver());
        }
        vida -= 1;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Definitive");
        }
    }
}
