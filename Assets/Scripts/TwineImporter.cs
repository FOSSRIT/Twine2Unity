﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class TwineImporter
{

    // Use this for initialization
    List<string> twineDataList = new List<string>();
	TwineData twineData;

    public TwineImporter()
    {
        //string path = Application.dataPath + @"/Resources/dialogue.txt";
        ReadTwineData();
        //ShowTwineData(twineData);
		ParseTwineData(twineDataList);
    }

    public void ReadTwineData()
	{
        string temp;
        string[] file;
		string[] split = {"::"};

		temp = Resources.Load("dialogueNew", typeof(TextAsset)).ToString();

        try
        {
            //create a stream reader
            //get the data in the text file
            //close the stream reader
            //StreamReader sr = new StreamReader(path);
            //temp = sr.ReadToEnd();
            //sr.Close();

            //parse large string by lines into an list
			file = temp.Split(split, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in file)
            {
                twineDataList.Add("::" + s);
            }
        }

        catch (FileNotFoundException e)
        {
            Debug.Log("The process failed: {0}" + e.ToString());
            return;
        }
    }

    void ShowTwineData(List <string> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log("Data Set "+i+": "+ data[i]);
        }
    }

	public void ParseTwineData(List<string> data)
    {
    	/*for (int i = 0; i < data.Count; i++)
        {
			TwineNode twineNode = new TwineNode(data[i], ':');
			twineNodes[i] = twineNode;
        }
		//current = twineData[0];
		twineData.current = twineNodes [0];*/
		string[] split = {":","\r\n"};
		twineData = new TwineData(data, split);
    }

	public TwineData TwineData
	{
		get
		{
			return twineData;
		}
	}

    // Update is called once per frame
    void Update()
    {


    }


}