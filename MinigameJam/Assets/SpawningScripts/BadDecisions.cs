using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadDecisions : MonoBehaviour
{
    private TextMeshProUGUI textyMesh;
    public int rangeMin = 10;
    public int rangeMax = 40;

    //enum events { CivilianConscription, HumanExperiments, ResourcesToMilitary,
    //ResourcesToCivilians, ResourcesToScientists, ArmyTraining, ResearchGrant,
    //FoodShortage, PowerOutage, LackOfMilitaryResources}

    int milInfluence = 50 + IsFinished.number * 5;
    int civilInfluence = 50 + IsFinished.number * 5;
    int sciInfluence = 50 + IsFinished.number * 5;

    bool notClickedYet = true;

    //int x;

    string textule;

    public GameObject buton1;
    public GameObject buton2;
    public GameObject esc;

    bool yes;
    bool no;

    public void YesPressed()
    {
        yes = true;
    }

    public void NoPressed()
    {
        no = true;
    }

    public void MakeDecision()
    {
        if(no == false && yes == false)
        {
            switch(Random.Range(1, 10))
            {
                case 1:  textule = "Conscript civilians into military"; break ;
                case 2:  textule = "Allow human experiments"; break ;
                case 3:  textule = "Grant resources to military"; break ;
                case 4:  textule = "Grant resources to civilians"; break ;
                case 5:  textule = "Grant resources to scientists"; break;
                case 6:  textule = "Allow army training exercise"; break ;
                case 7:  textule = "Research grant for scientists"; break ;
                case 8:  textule = "Food shortage in the bunker"; break ;
                case 9:  textule = "Power outage in the bunker"; break ;
                case 10: textule = "Lack of military resources"; break ;
            }                     
        }

        if (no == true && yes == false)
        {
            switch (Random.Range(1, 10))
            {
                case 1:
                    textule = "Conscript civilians into military";
                    civilInfluence += Random.Range(rangeMin, rangeMax);
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 2:
                    textule = "Allow human experiments";
                    civilInfluence += Random.Range(rangeMin, rangeMax);
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 3:
                    textule = "Grant resources to military";
                    civilInfluence += Random.Range(rangeMin, rangeMax);
                    sciInfluence += Random.Range(rangeMin, rangeMax);
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 4:
                    textule = "Grant resources to civilians";
                    civilInfluence -= Random.Range(rangeMin, rangeMax);
                    sciInfluence += Random.Range(rangeMin, rangeMax);
                    milInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 5:
                    textule = "Grant resources to scientists";
                    civilInfluence += Random.Range(rangeMin, rangeMax);
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    milInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 6:
                    textule = "Allow army training exercise";
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 7:
                    textule = "Research grant for scientists";
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 8:
                    textule = "Food shortage in the bunker";
                    civilInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 9:
                    textule = "Power outage in the bunker";
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 10:
                    textule = "Lack of military resources";
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
            }
        }

        if (no == false && yes == true)
        {
            switch (Random.Range(1, 10))
            {
                case 1:
                    textule = "Conscript civilians into military";
                    civilInfluence -= Random.Range(rangeMin, rangeMax);
                    milInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 2:
                    textule = "Allow human experiments";
                    civilInfluence -= Random.Range(rangeMin, rangeMax);
                    sciInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 3:
                    textule = "Grant resources to military";
                    civilInfluence -= Random.Range(rangeMin, rangeMax);
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    milInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 4:
                    textule = "Grant resources to civilians";
                    civilInfluence += Random.Range(rangeMin, rangeMax);
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 5:
                    textule = "Grant resources to scientists";
                    civilInfluence -= Random.Range(rangeMin, rangeMax);
                    sciInfluence += Random.Range(rangeMin, rangeMax);
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 6:
                    textule = "Allow army training exercise";
                    milInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 7:
                    textule = "Research grant for scientists";
                    sciInfluence += Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 8:
                    textule = "Food shortage in the bunker";
                    civilInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 9:
                    textule = "Power outage in the bunker";
                    sciInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
                case 10:
                    textule = "Lack of military resources";
                    milInfluence -= Random.Range(rangeMin, rangeMax);
                    yes = false;
                    no = false;
                    notClickedYet = false;
                    break;
            }
        }
    }

    void Start()
    {
        yes = false;
        no = false;
        int x = Random.Range(1, 10);
        textyMesh = GetComponent<TextMeshProUGUI>();
        textyMesh.text = "The gates of the bunker have been closed";
    }

    void Update()
    {
        if(notClickedYet == true)
            textyMesh.text = "The gates of the bunker have been closed,you must manage the factions in your bunker";
        else
            textyMesh.text = textule;
        if (milInfluence <= 0 || civilInfluence <= 0 || sciInfluence <= 0)
        {
            textyMesh.text = "Game Over,the factions in your bunker overthrew you";
                
            buton1.SetActive(false);
            buton2.SetActive(false);
            StartCoroutine (Exit());
            esc.SetActive (true);
            if (Input.GetKeyDown (KeyCode.Escape))
            {
                Application.Quit ();
            }
        }
    }
    IEnumerator Exit()
    {

        yield return new WaitForSeconds (10f);

        SceneManager.LoadScene (0);
    }
}
