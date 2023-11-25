using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityGoogleDrive;
using UnityGoogleDrive.Data;

public static class StatsSave
{
    private const string FileId = "1jFIz4-R1XhBnLO9E0-2w2BgZ3gSalqzB";
    
    public static List<File> FileList()
    {
        List<File> outputFiles = new List<File>();
        GoogleDriveFiles.List().Send().OnDone += filelist => { outputFiles = filelist.Files; };
        return outputFiles;
    }

    public static File Upload(String obj, Action onDone = null)
    {
        Debug.Log(FileList().Count);
        var file = new File { Name = "GameData.json", Content = Encoding.ASCII.GetBytes(obj) };
        GoogleDriveFiles.Update(FileId, file).Send();
        return file;
    }

    public static File DownLoad()
    {
        File output = new File();
        GoogleDriveFiles.Download(FileId).Send().OnDone += file => { output = file; };
        return output;
    }
}
