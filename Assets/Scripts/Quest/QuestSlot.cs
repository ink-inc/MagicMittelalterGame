﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{
    public TextMeshProUGUI questName;
    //public Text questName;
    public void Display(Quest quest)
    {
        this.questName.text = quest.questName;
        Logger.log("dasd");
    }
}