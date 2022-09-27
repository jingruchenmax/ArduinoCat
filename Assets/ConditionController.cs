using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ConditionController : MonoBehaviour
{
    public Slider HPSlider;
    public Slider HungerSlider;
    public Slider HappynessSlider;
    public Slider ThirstSlider;
    public GameObject theend;
    public int HP=10;
    public int Hunger=100;
    public int Happyness=100;
    public int Thirst=100;
    public int need=5;
    // Start is called before the first frame update
    void Start()
    {
        theend.SetActive(false);
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
            theend.SetActive(true);
            Invoke("restart", 5);
        }
        UpdateSliderValues();
    }

    public void AddHunger()
    {
        Hunger += need;
        UpdateSliderValues();
    }

    public void AddHappyness()
    {
        Happyness += need;
        UpdateSliderValues();
    }
    public void AddThirst()
    {
        Thirst += need;
        UpdateSliderValues();
    }

    void UpdateSliderValues()
    {
        Hunger=Mathf.Clamp(Hunger, 0,100);
        Thirst= Mathf.Clamp(Thirst, 0, 100);
        Happyness=Mathf.Clamp(Happyness, 0, 100);
        HungerSlider.value = Hunger / 100f;
        HappynessSlider.value = Happyness / 100f;
        ThirstSlider.value = Thirst / 100f;
        HPSlider.value = HP / 10f;
    }

    void restart()
    {
        SceneManager.LoadScene(0);
    }

}
