using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReadOrder { RTL, LTR }
[CreateAssetMenu(
    fileName = "New Alphabet",
    menuName = "Localization/Alphabet",
    order = 2)]
public class Alphabet : ScriptableObject
{
    public ReadOrder ReadOrder;
}
