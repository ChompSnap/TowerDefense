using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bankInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getBankInt()
    {
        return bankInt;
    }
    public void setBankInt(int value)
    {
        bankInt = value;
    }
}
