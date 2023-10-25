﻿using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CheatCode
{
    public string cheatCode;
    public Action cheat;
    public List<string> tries = new();
    public CheatCode(string cheatCode, Action cheat)
    {
        this.cheatCode = cheatCode;
        this.cheat = cheat;
    }
    public void Check(char c)
    {
        for (int i = 0; i < tries.Count;)
        {

            if (tries[i][0] != c)
            {
                tries.RemoveAt(i);
                continue;
            }

            if (tries[i].Length == 1)
            {
                tries.RemoveAt(i);
                cheat();
                continue;
            }
                tries[i] = tries[i++][1..];          

        }
        if (c == cheatCode[0])
        {
            tries.Add(cheatCode[1..]);
        }
    }

    public  static void Update(List<CheatCode> cheats)
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    foreach (var item in cheats)
                    {
                        item.Check(char.ToLower(kcode.ToString()[0]));
                    }
                    return;
                }
            }
            return;

        }
    }
}