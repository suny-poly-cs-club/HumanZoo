using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Main : MonoBehaviour
{
    int index = 0;
    string path = "Assets/Resources/scannedImages/";
    public GameObject characterRectangle;
    FileInfo[] files;
    // Start is called before the first frame update
    void Start()
    {
       
        DirectoryInfo directory = new DirectoryInfo(path);
        files = directory.GetFiles("*.*");
    }

    // Update is called once per frame
    void Update()
    {
        import();
    }

    public void import()
    {
        var scannedSprite = getImage();
        print(scannedSprite);
        if(scannedSprite!=null)
        {
            GameObject character = Instantiate(characterRectangle, new Vector2(0, 0), Quaternion.identity);
            character.GetComponent<SpriteRenderer>().sprite = scannedSprite;
        }
    }

     Sprite getImage()
    {
        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] newFiles = directory.GetFiles("*.*");

        List<FileInfo> addedFiles = new List<FileInfo>();
        foreach(FileInfo f in newFiles)
        {
            bool isSame = false;
            foreach(FileInfo g in files)
            {
                if(g==f)
                {
                    isSame = true;
                }
            }
            if(isSame)
            {
                addedFiles.Add(f);
            }
        }
        string s = "[";
        foreach(FileInfo name in addedFiles)
        {
            s += name + ",";
        }
        s += "]";
        print(s);

        print(index);
        if(addedFiles.Count>0)
        {
            index++;
            FileInfo file = addedFiles[0];
            string fileName = file.Name;
            print(fileName);
            var scannedSprite = Resources.Load<Sprite>("scannedImages/"+fileName);
            return scannedSprite;
        }
        else
        {
            return null;
        }
      
    }
}
