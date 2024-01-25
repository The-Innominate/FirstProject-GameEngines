using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;

    Coroutine timerCoroutine;

    void Start()
    {
        StartCoroutine(Timer(time));
        StartCoroutine("StoryTime");
        StartCoroutine(WaitAction());
    }

    void Update()
    {
        //time -= Time.deltaTime;
        //if (time <= 0)
        //{
        //    time = 3;
        //    print("Hello");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true) {
            yield return new WaitForSeconds(time);
            //Check Perception
            print("Hello");
        }
        //yield return null;
    }

    IEnumerator StoryTime()
    {
        print("Hello");
        yield return new WaitForSeconds(time);
        print("Welcome to the new world");
        yield return new WaitForSeconds(time);
        print("You are the chosen one");

        StopCoroutine(timerCoroutine);

        yield return null;
    }

    IEnumerator WaitAction()
    {
        yield return new WaitWhile(() => go);
        print("Hello");
        yield return null;
    }
}
