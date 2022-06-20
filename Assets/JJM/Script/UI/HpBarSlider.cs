using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarSlider : MonoBehaviour
{
    public Slider hpBar_Front;
    public Slider hpBar_Back;

    public float maxHp = 100f;
    public float currentHp = 100f;
    // Start is called before the first frame update
    void Start()
    {
        if(!hpBar_Front) hpBar_Front = transform.Find("HpSlider").GetComponent<Slider>();
        if(!hpBar_Back) hpBar_Back = transform.Find("BackHpSlider").GetComponent<Slider>();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) //Test
        {
            OnDamage(10f);
        }
    }

    public void OnDamage(float dmg) //데미지 함수
    {
        StopAllCoroutines();

        currentHp -= dmg;
        StartCoroutine(AddDamage(hpBar_Front, dmg, 0f));
        StartCoroutine(AddDamage(hpBar_Back, dmg, 0.3f));
    }

    public IEnumerator AddDamage(Slider slider, float dmg, float time) //Slider value 설정
    {
        yield return new WaitForSeconds(time);

        while (Mathf.Abs(slider.value - currentHp/maxHp) > 0.0001f) 
        {
            slider.value = Mathf.Lerp(slider.value, currentHp / maxHp, Time.deltaTime * 5f);

            yield return new WaitForSeconds(0.01f);
        }

        slider.value = currentHp / maxHp;
    }
}
