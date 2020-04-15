using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private int count;
    private float timer;
    public Text countText;
    public Text WinText;
    public Text TimeText;
    public AudioSource cubeSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "COUNT: " + count.ToString();
        WinText.text = "";
        timer = Time.deltaTime;
        cubeSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        timer = timer + Time.deltaTime;

        Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(force*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
            cubeSource.Play();
        }

        if(count >= 10)
        {
            WinText.text = "You Win! ";
            TimeText.text = timer.ToString() + " seconds";

        }
    }
}
/*Destroy(other.gameObject);
if (other.gameObject.CompareTag("Player"))
{
            gameObject.SetActive(false);
}*/