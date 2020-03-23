using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject
{
    private string type { get; set; } // line or decision
    private string dialogLine { get; set; }
    private string[] dialogDecisions { get; set; }
}
