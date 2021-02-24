using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject textbox;
    [SerializeField] private string text;
    private GameObject npc;
    private Rigidbody rbNPC;
    // Start is called before the first frame update
    void Start()
    {
        npc = transform.parent.gameObject;
        rbNPC = npc.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            panel.SetActive(true);
            textbox.GetComponent<Text>().text = text;
            rbNPC.AddForce(new Vector3(0, 3, 0), ForceMode.VelocityChange);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            panel.SetActive(false);
        }
    }
}
