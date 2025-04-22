using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GradualBgChange : MonoBehaviour
{
    [SerializeField] private Image moon;
    [SerializeField] private Image sun;
    [SerializeField] private float imgfade = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (moon != null && sun != null)
        {
            StartCoroutine(ChangeImages());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeImages()
    {
        float imgtimer = 0f;

        sun.gameObject.SetActive(true);
        sun.color = new Color(sun.color.r, sun.color.g, sun.color.b, 0f);
        
        while (imgtimer < imgfade)
        {
            imgtimer += Time.deltaTime;
            float alpha = imgtimer / imgfade;

            moon.color = new Color(moon.color.r, moon.color.g, moon.color.b, 1f - alpha);
            sun.color = new Color(sun.color.r, sun.color.g, sun.color.b, alpha);

            yield return null;
        }
        moon.gameObject.SetActive(false);
        sun.color = new Color(sun.color.r, sun.color.g, sun.color.b, 1f);
    }

}
