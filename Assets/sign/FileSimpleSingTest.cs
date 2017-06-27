using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileSimpleSingTest : MonoBehaviour
{
    public string filePath;
    public string filePath1;
    public string fileSign;
    public string fileSign1;

    // Use this for initialization
    void Start ()
    {
        //FileStream file = new FileStream(filePath, FileMode.Open);
        //FileInfo info = new FileInfo(filePath);
        //file.Seek(info.Length-1, SeekOrigin.Begin);
        //Debug.Log(file.ReadByte());
        //file.Flush();
        //return;
        fileSign = FileQuickSign.GenSign8(filePath);
        fileSign1 = FileQuickSign.GenSign8(filePath1);

        Debug.Log(fileSign == fileSign1);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
