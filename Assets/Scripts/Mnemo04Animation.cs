using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mnemo04Animation : MonoBehaviour
{
    public GameObject Mnemo02;
    public GameObject Mnemo03;
    public GameObject Mnemo05;
    private Animation animmnemo04;
    private Animation animmnemo03;

    public GameObject Shiberm;
    public GameObject Ramka;
    public GameObject M03m;

    public GameObject mnemo0404;
    public GameObject mnemo0402;
    public GameObject mnemo04051;
    public GameObject mnemo04052;

    public Animator Ustanovkapozitsiitvela;
    public Animator Ustanovkarazborkimagtvel;

    [SerializeField] private Text equippedFuelRodsText;
    [SerializeField] private Text currentFuelRodNumberText;
    [SerializeField] private Text pushPositionText;

    private int countpushPosition = 0;
    private List<string> pushPositions = new() { "", "001", "079", "080", "081", "159", "160" };
    private readonly List<string> currentFuelRodNumbers = new() { "", "01001023", "01007923", "01008023", "01008123", "01015923", "01016023" };

    public Text CurrentFuelRodNumberText { get => currentFuelRodNumberText; set => currentFuelRodNumberText = value; }

    // Start is called before the first frame update
    void Start()
    {
        animmnemo04 = gameObject.GetComponent<Animation>();
        animmnemo03 = Mnemo03.GetComponent<Animation>();
    }

    private void Mnemo03Off()
    {
        Shiberm.SetActive(false);
        Ramka.SetActive(false);
        M03m.SetActive(false);
    }

    private void Mnemo03On()
    {
        Shiberm.SetActive(true);
        Ramka.SetActive(true);
        M03m.SetActive(true);
    }

    public void Mnemo04Off()
    {
        if (countpushPosition == 3)
        {
            return;
        }
        if (countpushPosition < 6)
            animmnemo03.Play("03 Mnemo Animation1");
        else
        {
            Mnemo03.SetActive(false);
            Mnemo05.SetActive(true);
        }
    }

    public void UstanovkapozitsiitvelaRun()
    {
        Ustanovkapozitsiitvela.Play("CoordinateMoving", 0, 0f);
        animmnemo04.Play();
    }

    public void UstanovkapozitsiitvelaStop()
    {
        //Mnemo03Off();
        Ustanovkapozitsiitvela.enabled = false;
    }

    public void UstanovkapozitsiitvelaPlay()
    {
        Ustanovkapozitsiitvela.enabled = true;
    }

    public void UstanovkarazborkimagtvelPlay()
    {
        Ustanovkarazborkimagtvel.enabled = true;
    }

    public void Mnemo03Stop()
    {
        animmnemo03.Stop();
    }

    public void CurrentFuelRodNumber()
    {
        countpushPosition++;
        CurrentFuelRodNumberText.text = currentFuelRodNumbers[countpushPosition];
        pushPositionText.text = pushPositions[countpushPosition];
    }

    public void EquippedFuelRods()
    {
        equippedFuelRodsText.text = pushPositionText.text;
    }
}
