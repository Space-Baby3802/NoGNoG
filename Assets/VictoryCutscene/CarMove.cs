using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    [SerializeField] GameObject CarAndGold;
    [SerializeField] int carSpeed;
    [SerializeField] float changeTime;
    [SerializeField] GameObject panel;
    Color endColor = Color.clear;

    [SerializeField] public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
       // CarAndGold = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) 
        {
            changeTime += Time.deltaTime;
            endColor = Color.Lerp(Color.clear, Color.black, changeTime / 2);
            panel.GetComponent<Image>().color = endColor;
            Debug.Log(endColor.ToString());
            if (changeTime >= 5)
            {
                Application.Quit();
                Debug.Log("GameQuit!");
            }
        }
        CarAndGold.transform.position = new Vector3(CarAndGold.transform.position.x + 1 * carSpeed * Time.deltaTime, CarAndGold.transform.position.y, CarAndGold.transform.position.z);
       // panelFade();
       
    }

    private void panelFade()
    {
        
        endColor = Color.Lerp(Color.clear, Color.black, changeTime/2); 
        panel.GetComponent<Image>().color = endColor;
        Debug.Log(endColor.ToString());
    }
}
