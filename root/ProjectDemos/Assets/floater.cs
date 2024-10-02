using UnityEngine;

public class floater : MonoBehaviour
{
    //we only need to calulate the bouyant force once, then we just scale it from 0 to 1 based on its position

    float CalculateBouyantForceNewtons(float objectDensity, float cubicVolume)
    {
        float FB;
        const int forceMultiplier = 50; //unitys add force uses a scaled version of a newtons force, so this is to counteract that and approach a reasonable force value
        const float gravity = 9.81f;
        FB = objectDensity * cubicVolume * gravity;
        return FB * forceMultiplier;
    }

    float CalculateScaledForce(float newtons, float currentOceanYValue, float HeightOfObject)
    {
        if (transform.position.y >= currentOceanYValue)
        {
            return 0f;
        }

        //to determine how much of an object is under water, get the center of an object, add half of the height,
        //and then subtract the y value from the top. clamp this value below
        float scalar = (transform.position.y + (HeightOfObject / 2)) - currentOceanYValue;

        //calcuate the force by this number to return a scaled value
        float clampedVal = Mathf.Clamp01(scalar);

        //return force multiplied by scalar
        return newtons * clampedVal;
    }


    //what if we want to have multple floaters?


}
