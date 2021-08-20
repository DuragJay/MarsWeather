using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEffects : MonoBehaviour
{
    public Transform myObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myObj = this.GetComponent<Transform>();
      transform.Rotate(myObj.forward * Time.deltaTime * 100, Space.Self);
    }
}
