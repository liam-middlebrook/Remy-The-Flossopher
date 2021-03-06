﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TwineImporter 
{

    // Use this for initialization
    public TwineNode current = new TwineNode();
    public TwineNode Current {get{return current;} set{current = value;}}

    public List<string> twineInfo = new List<string>();

    public List<TwineNode> twineData = new List<TwineNode>();

    public TwineData data;

    public TwineImporter()
    {
        string path = Application.dataPath + @"\Resources\dialogue.txt";

        twineInfo = ReadTwineData(path);

        ParseTwineData(twineInfo);

        //data = new TwineData(twineInfo);

        //Debug.Log(Current);
        //ShowTwineData(twineInfo);

        //ParseTwineData(twineInfo);
    }

    public List<string> ReadTwineData(string path)
    {
        string temp;
        string[] file;

        try
        {
            //create a stream reader
            //get the data in the text file
            //close the stream reader
            StreamReader sr = new StreamReader(path);
            temp = sr.ReadToEnd();
            sr.Close();

            //parse large string by lines into an list
            file = temp.Split("\n"[0]);
            foreach (string s in file)
            {
                twineInfo.Add(s);
            }
            return twineInfo;
        }

        catch (FileNotFoundException e)
        {
            Debug.Log("The process failed: {0}" + e.ToString());
            return null;
        }
    }

    void ShowTwineData(List <string> data)
    {
        bool listedAll = false;

        if (listedAll == false)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (i == data.Count)
                {
                    listedAll = true;
                }

                Debug.Log(data[i]);
            }
        }
    }

    public void ParseTwineData(List<string> rawData)
    {
    	for (int i = 0; i < rawData.Count; i++)
        {
            TwineNode twineNode = new TwineNode();
            twineData.Add(twineNode.Parse(rawData[i]));
        }
        current = twineData[0];
    }

    // Update is called once per frame
    void Update()
    {


    }


}