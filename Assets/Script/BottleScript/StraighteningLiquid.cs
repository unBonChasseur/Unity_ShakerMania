using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraighteningLiquid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //Vector3 tmp_pos = new Vector3(0, transform.position.y + transform.lossyScale.y/2, 0);
        //transform.position = tmp_pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
