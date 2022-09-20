using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionController : MonoBehaviour
{
    public int HPMax=10;
    public int HP=10;
    public int HungerMax=100;
    public int Hunger=100;
    public int HappynessMax=100;
    public int Happyness=100;
    public int ThirstMax=100;
    public int Thirst=100;
    public int need=5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CalucateBasicNeeds", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CalucateBasicNeeds()
    {
        Hunger -= need;
        Happyness -= need;
        Thirst -= need;
        if (Hunger <= 50 || Happyness<=50 || Thirst <= 50)
        {
            HP -= 1;
        }

        if (HP <= 0)
        {
            Debug.Log("Your cat has gone to a better place.");
        }
    }
}
