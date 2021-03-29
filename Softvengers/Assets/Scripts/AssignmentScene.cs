﻿using System.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class AssignmentScene : MonoBehaviour
{
    public string selectedAssignmentid;
    public GameObject PendingAssignment;
    public GameObject CompletedAssignment;
    public GameObject OverdueAssignment;
    // public GameObject infoContent;
    // public GameObject scroll;
    public Canvas start;
    public Canvas completed;
    public Canvas overdue;
    public bool start_a = false;
    public bool completed_a = false;
    public bool overdue_a = false;
    public List<string> pending_assignment = new List<string>();
    public List<string> completed_assignment = new List<string>();
    public List<string> overdue_assignment = new List<string>();

    // Start is called before the first frame update

    public static Dictionary<string, Dictionary<string, string>> Assign_info =
 new Dictionary<string, Dictionary<string, string>>()
 {
        {
            "01",
            new Dictionary<string, string>
            {
                {"name", "The Ultimate Assignment"},
                {"attempted","1" },
                {"c_score","200" },
                {"c_time", "7 min"},
                {"deadline","25/03/2021" }
            }
        },
        {
            "02",
            new Dictionary<string, string>
            {
                {"name", "Awesome Challenge"},
                {"attempted","0" },
                {"c_score","0" },
                {"c_time", "0"},
                {"deadline","24/03/2021" }
            }
        },
        {
            "03",
            new Dictionary<string, string>
            {
                {"name", "Infinity Stones"},
                {"attempted","0" },
                {"c_score","0" },
                {"c_time", "0"},
                {"deadline","27/03/2021" }
            }
        },
       

 };




    void Start()
    {

        foreach (var entry in Assign_info)
        {
            if (entry.Value["attempted"] == "0")
            {
                DateTime localdate = DateTime.Now;
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime assign_deadline = DateTime.ParseExact(entry.Value["deadline"], "dd/MM/yyyy", provider);

                Debug.Log(localdate);
                Debug.Log(assign_deadline);
                Debug.Log(DateTime.Compare(localdate, assign_deadline));
                if (DateTime.Compare(localdate, assign_deadline) > 0)
                    overdue_assignment.Add(entry.Key);
                else
                    pending_assignment.Add(entry.Key);

            }
            else
            {
                completed_assignment.Add(entry.Key);
            }
        }

        Vector3 curPos = new Vector3(-12, -86, 0);
        foreach (var item in pending_assignment)
        {

            var newPA = Instantiate(PendingAssignment, gameObject.transform, false);
            newPA.name = item;
            newPA.transform.localPosition = curPos;
            foreach (Transform child in newPA.transform)
            {
                if (child.name == "StartButton")
                {
                    Button btn = child.GetComponentInChildren<Button>();
                    btn.onClick.AddListener(start_pop);
                    btn.onClick.AddListener(delegate {
                        setSelectedID(btn);
                    });
                }
               
                else if (child.name == "SnoText")
                {
                    Text sText = child.GetComponentInChildren<Text>();
                    sText.text = item;
                }
                else if (child.name == "Aname")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["name"];
                }
                else if (child.name == "Time")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["c_time"];
                }
                else if (child.name == "Score")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["c_score"];
                }
                else if (child.name == "Deadline")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["deadline"];
                }

            }
            curPos -= new Vector3(0, 65, 0);

        }

        foreach (var item in overdue_assignment)
        {

            var newPA = Instantiate(OverdueAssignment, gameObject.transform, false);
            newPA.name = item;
            newPA.transform.localPosition = curPos;
            foreach (Transform child in newPA.transform)
            {
               
                if (child.name == "OverdueButton")
                {
                    Button btn = child.GetComponentInChildren<Button>();
                    btn.onClick.AddListener(overdue_pop);
                    btn.onClick.AddListener(delegate {
                        setSelectedID(btn);
                    });
                    
                }
                else if (child.name == "SnoText")
                {
                    Text sText = child.GetComponentInChildren<Text>();
                    sText.text = item;
                }
                else if (child.name == "Aname")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["name"];
                }
                else if (child.name == "Time")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["c_time"];
                }
                else if (child.name == "Score")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["c_score"];
                }
                else if (child.name == "Deadline")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["deadline"];
                }

            }
            curPos -= new Vector3(0, 65, 0);

        }

        foreach (var item in completed_assignment)
        {

            var newPA = Instantiate(CompletedAssignment, gameObject.transform, false);
            newPA.name = item;
            newPA.transform.localPosition = curPos;
            foreach (Transform child in newPA.transform)
            {
                if (child.name == "CompletedButton")
                {
                    Button btn = child.GetComponentInChildren<Button>();
                    btn.onClick.AddListener(completed_pop);
                    btn.onClick.AddListener(delegate {
                        setSelectedID(btn);
                    });
                }
                
                else if (child.name == "SnoText")
                {
                    Text sText = child.GetComponentInChildren<Text>();
                    sText.text = item;
                }
                else if (child.name == "AnameText")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["name"];
                }
                else if (child.name == "Time")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["c_time"];
                }
                else if (child.name == "Score")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["c_score"];
                }
                else if (child.name == "Deadline")
                {
                    Text cText = child.GetComponentInChildren<Text>();
                    cText.text = Assign_info[item]["deadline"];
                }

            }
            curPos -= new Vector3(0, 65, 0);

        }





    }

    public void start_pop()
    {
        if (start_a == false)
        {
            start_a = true;
            start.enabled = true;
            completed_a = false;
            completed.enabled = false;
            overdue_a = false;
            overdue.enabled = false;
        }
        else if (start_a == true)
        {
            start_a = false;
            start.enabled = false;
        }
    }

    public void completed_pop()
    {
        if (completed_a == false)
        {
            completed_a = true;
            completed.enabled = true;
            start_a = false;
            start.enabled = false;
            overdue_a = false;
            overdue.enabled = false;
        }
        else if (completed_a == true)
        {
            completed_a = false;
            completed.enabled = false;
        }
    }

    public void overdue_pop()
    {
        if (overdue_a == false)
        {
            overdue_a = true;
            overdue.enabled = true;
            start_a = false;
            start.enabled = false;
            completed_a = false;
            completed.enabled = false;
        }
        else if (overdue_a == true)
        {
            overdue_a = false;
            overdue.enabled = false;
        }
    }

    public void setSelectedID(Button btn)
    {
        selectedAssignmentid = btn.transform.parent.gameObject.name;
    }

    /*public void setInfopopup()
    {
        Scrollbar s = scroll.GetComponent<Scrollbar>();
        s.value = 1;
        foreach (Transform child in infoContent.transform)
        {
            if (child.name == "Cname")
            {
                Text sText = child.GetComponentInChildren<Text>();
                sText.text = RC_info[selectedChallengeid]["sender"];
            }
            else if (child.name == "CTime")
            {
                Text cText = child.GetComponentInChildren<Text>();
                cText.text = RC_info[selectedChallengeid]["c_time"];
            }
            else if (child.name == "Cscore")
            {
                Text cText = child.GetComponentInChildren<Text>();
                cText.text = RC_info[selectedChallengeid]["c_score"];
            }
            else if (child.name == "ScoreMessage")
            {
                Text cText = child.GetComponentInChildren<Text>();
                if (RC_info[selectedChallengeid]["attempted"] == "0")
                {
                    cText.text = "Can you beat this score?";
                }
                else if (int.Parse(RC_info[selectedChallengeid]["c_score"]) <= int.Parse(RC_info[selectedChallengeid]["your_score"]))
                {
                    cText.text = "Good Job!";
                }
                else
                {
                    cText.text = "Better luck next time";
                }
            }
            else if (child.name == "Topic List")
            {
                Text cText = child.GetComponentInChildren<Text>();
                string topics = "";
                foreach (var item in topic_info[selectedChallengeid])
                {
                    topics += item + "\n";
                }
                cText.text = topics;


            }
        }

    }

    public void OnDeclineYes()
    {
        bool start_shift = false;
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "ContentHeading")
            {
                continue;
            }
            else if (child.name == selectedChallengeid)
            {
                Destroy(child.gameObject);
                start_shift = true;
            }
            else if (start_shift)
            {
                child.localPosition += new Vector3(0, 65, 0);
            }
        }
    }*/

    public void OnAcceptYes()
    {
        //add code to load new game scene and send challenge id to db
    }
}
