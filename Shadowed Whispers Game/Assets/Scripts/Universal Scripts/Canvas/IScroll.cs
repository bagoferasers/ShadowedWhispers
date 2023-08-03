using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScroll
{
    Vector3 startPosition{ get; }
    void Scroll( Vector3 currentPosition );
}