﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResourceManager : MonoBehaviour {
    public Text ResourceDisplayText;
    public float upkeep = 0;
    public float income=0;
    public float resource=5;
    public bool Affordable(Entity e)
    {
        if (resource>=e.cost)
        {
            return true;
        }
        return false;
    }

    private void Awake()
    {
        Global.myPlayerResourceManager = this;
    }

    public void StartTurn()
    {
        resource += upkeep;
        resource += income;
    }

    public bool PlayCard(Entity card)
    {
        if (resource < card.cost)
        {
            return false;
        }
        resource -= card.cost;
        return true;
    }

    public void AddUpkeep(Entity card)
    {
        upkeep += card.Upkeep;
    }

    public void SubtractUpkeep(Entity card)
    {
        upkeep -= card.Upkeep;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float TotalIncome = income + upkeep;
        string IncomeString = TotalIncome.ToString();
        if (TotalIncome>0)
        {
            IncomeString = "+"+TotalIncome.ToString();
        }
        
        ResourceDisplayText.text = "Gold: " + resource+ " ("+(IncomeString)+")";
    }
}
