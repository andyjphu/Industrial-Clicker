using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageOfTime : MonoBehaviour
{
    public int[] startDate = { 1, 1, 1760 };
    public GameObject[] disableWhenPaused;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine("GameLoop");
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            print("yeehaw");

            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            StopCoroutine("GameLoop");
            Time.timeScale = 0;
            GameObject.Find("$Storage").GetComponent<ResourceStorage>().gameIsPaused = true;
            foreach (var obj in disableWhenPaused)
            {
                //obj.SetActive(false);
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            StartCoroutine("GameLoop");
            Time.timeScale = 1;
            GameObject.Find("$Storage").GetComponent<ResourceStorage>().gameIsPaused = false;
            foreach (var obj in disableWhenPaused)
            {
                obj.SetActive(true);
            }
        }
    }
}