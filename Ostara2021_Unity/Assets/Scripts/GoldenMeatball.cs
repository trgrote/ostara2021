using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenMeatball : MonoBehaviour
{
    [SerializeField] rho.ExternalVariable<bool> _isMeatballRun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("goldenmeatballgoal"))
        {
            _isMeatballRun.Value = true;
        }
    }
}
