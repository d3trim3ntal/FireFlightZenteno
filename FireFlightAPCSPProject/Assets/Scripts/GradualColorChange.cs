using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GradualColorChange : MonoBehaviour
{
    [SerializeField] private Image bgImage;
    [SerializeField] private Color[] colors; // List of colors that can be editted in the inspector
    [SerializeField] private float duration = 1f; // Time it take for colors to change

    private int currentColor = 0; // Current color program is on

    // Start is called before the first frame update
    void Start()
    {
        if (bgImage != null && colors.Length > 0)
        {
            StartCoroutine(ChangeGradually());
        }
    }

    IEnumerator ChangeGradually()
    {
        while (currentColor < colors.Length - 1)
        {
            int nextColor = currentColor + 1;

            float timer = 0f;
            while (timer < duration)
            {
                timer += Time.deltaTime;
                bgImage.color = Color.Lerp(colors[currentColor], colors[nextColor], timer / duration);
                yield return null;
            }

            currentColor = nextColor;
        }
    }
}
