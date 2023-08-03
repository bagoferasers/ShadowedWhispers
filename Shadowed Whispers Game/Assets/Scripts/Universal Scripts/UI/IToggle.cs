using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IToggle
{
    Toggle toggle{ get; }
    void changedToggle( string toggleName, bool isOn );
}
