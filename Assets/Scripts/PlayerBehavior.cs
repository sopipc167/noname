using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rd;
    int f = 5;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        GameObject player = GameObject.Find("New Sprite");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("d");
            rd.AddForce(new Vector3(1f, 0f, 0f));
            gameObject.transform.Translate(new Vector3(1f,0f,0f) * Time.deltaTime);
        }
        StartCoroutine(test());
        StartCoroutine("test");
    }
    IEnumerator test()
    {

        yield return new WaitForSeconds(0.1f);
    }
}
