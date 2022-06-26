using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{
    public int punchCount;
    public int punchWait;

    public GameObject punch1;
    public GameObject punch2;
    public GameObject punch3;

    public Transform punchHitbox;
    public LayerMask enemy;
    public float hitboxSize = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (punchWait >= 100)
        {
            punchCount = 0;
            punchWait = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            punchCount += 1;
            punchWait = 0;
        }

        if (punchCount == 0)
        {
            punch1.SetActive(false);
            punch2.SetActive(false);
            punch3.SetActive(false);
        }

        if (punchCount == 1)
        {
            punch1.SetActive(true);
            punch2.SetActive(false);
            punch3.SetActive(false);
            punchWait += 1;
        }

        if (punchCount == 2)
        {
            punch1.SetActive(false);
            punch2.SetActive(true);
            punch3.SetActive(false);
            punchWait += 1;
        }

        if (punchCount == 3)
        {
            StartCoroutine(punchDelay());
        }
    }

    IEnumerator punchDelay()
    {
        if (punchCount == 3)
        {
            punch3.SetActive(true);
            punch1.SetActive(false);
            punch2.SetActive(false);
            yield return new WaitForSeconds(.5f);
            punchCount = 0;
        }
    }
}
