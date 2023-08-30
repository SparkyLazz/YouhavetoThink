using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialougeSentenes
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentence;
    [TextArea(3, 10)]
    public string[] afterCondition;
}
