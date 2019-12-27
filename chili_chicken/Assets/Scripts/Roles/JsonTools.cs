using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonTools 
{
    private static string base_datapath = Application.dataPath + "/Resources/data/";
    private static string text_datapath = "Role_text.json";
    private static string history_datapath = "Player_state.json";
    private static string testjson = "testjson.json";
    private static Dictionary<string, string> temp = new Dictionary<string, string>();
    
    public static void updateState(string key,string value)
    {
        if (temp.ContainsKey(key)) // 已经存在此项
        {
            temp[key] = value;
        }
        else
        {
            temp.Add(key, value);
        }
    }
    public static void save(Role role)
    {
        InfoItem infoitem = new InfoItem(role);
        infoitem.otherstates = temp;
        saveToJson(infoitem);
    }

    public static void trans_save(PlayerInfo playerinfo)
    {
        string saveString = JsonConvert.SerializeObject(playerinfo);
        WriteFile(base_datapath + "testjson.json", saveString);
        Debug.Log(saveString);
        Debug.Log("Archive successfully");
    }
    public static void saveToJson(InfoItem infoitem)
    {
        PlayerInfo playerinfo = readArchive();
        bool isAdd = true;
        //存档不为空
        if (playerinfo != null)
        {

            for(int i = 0; i < playerinfo.inforList.ToArray().Length; i++)
            {
                //存在改存档，修改存档即可
                if(playerinfo.inforList[i].id == infoitem.id)
                {
                    playerinfo.inforList[i] = infoitem;
                    isAdd = false;
                }
            }
            //如果不存在此项存档,添加存档
            if (isAdd)
                playerinfo.inforList.Add(infoitem);

            trans_save(playerinfo);
        }
        else
        {
            Debug.LogError("Archive failed");
        }

    }

    public static void WriteFile(string path, string content)
    {
        if (Directory.Exists(path))
        {
            File.Delete(path);
        }
        File.WriteAllText(path, content);
    }

    public static PlayerInfo readArchive()
    {
        if (!File.Exists(base_datapath + testjson))
        {
            FileStream f = File.Create(base_datapath + testjson);
            /*f.Close();
            f.Dispose();*/
            Debug.LogError("path error");
            return null;
        }

        StreamReader sr = new StreamReader(base_datapath + testjson);
        string json = sr.ReadToEnd();
        //Debug.LogError(json);
        sr.Close();

        PlayerInfo playerinfo = new PlayerInfo();

        if (json.Length > 0)
        {
            playerinfo = JsonConvert.DeserializeObject<PlayerInfo>(json);
        }

        return playerinfo;
    }
    public static List<string> getArchive()
    {
        PlayerInfo playerinfo = readArchive();
        if(playerinfo == null)
        {
            Debug.LogError("Get archive failed");
            return null;
        }
        else
        {
            List<string> result = new List<string>();
            string temp = "";
            for(int i = 0; i < playerinfo.inforList.ToArray().Length; i++)
            {
                temp = "" + playerinfo.inforList[i].id + " " + playerinfo.inforList[i].Type;
                result.Add(temp);
            }
            return result;
        }
    }
    public static bool removeArchive(int id)
    {
        PlayerInfo playerinfo = readArchive();
        if (playerinfo == null)
        {
            Debug.LogError("Remove archive failed");
            return false;
        }
        else
        {
            for (int i = 0; i < playerinfo.inforList.ToArray().Length; i++)
            {
               if(playerinfo.inforList[i].id == id)
                {
                    playerinfo.inforList.RemoveAt(i);
                    trans_save(playerinfo);
                    return true;
                }
            }
        }
        return false;
    }
    public static string getRoleDescription(int Type)
    {
        RoleDescription role_d = readRoleDescription();
        if (role_d == null)
            return "hello";
        switch (Type)
        {
            case 1:
                Debug.Log("Obtain role description successfully");
                return role_d.Lolita_d;
            case 2:
                Debug.Log("Obtain role description successfully");
                return role_d.Genius_d;
            case 3:
                Debug.Log("Obtain role description successfully");
                return role_d.Liver_Emperor_d;
            case 4:
                Debug.Log("Obtain role description successfully");
                return role_d.Master_of_Sports_d;
            case 5:
                Debug.Log("Obtain role description successfully");
                return role_d.Young_Aritst_d;
            case 6:
                Debug.Log("Obtain role description successfully");
                return role_d.Computer_Guy_d;
            defualt: return "this";
        }
        return "mother";
    }
    private static RoleDescription readRoleDescription()
    {
        if (!File.Exists(base_datapath + text_datapath))
        {

            Debug.LogError("Obtain description failed");
            return null;
        }

        StreamReader sr = new StreamReader(base_datapath + text_datapath);
        string json = sr.ReadToEnd();

        sr.Close();
        //Debug.LogError(json);
        RoleDescription role_d = new RoleDescription();

        if (json.Length > 0)
        {
            role_d = JsonUtility.FromJson<RoleDescription>(json);
        }
        return role_d;
    }
}
