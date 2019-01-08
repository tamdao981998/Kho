using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class data_game : MonoBehaviour
{
    public static data_game intance;
    string file_name = "savedGame.gd"; //tên file sẽ lưu trữ trong bộ nhớ điện thoại cùng ở thư mục mà ứng dụng lưu trữ

    void Start()
    {

    }
    private void Intance()
    {
        if(intance==null)
        {
            intance = this;
        }
    }
    //Ghi file điểm
    public void write_socer(int best_score)
    {
        ArrayList arraySocer = new ArrayList();
        ConvertScenes ps = new ConvertScenes();
        ps.best_socer = best_score;
        arraySocer.Add(ps);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + file_name);
        bf.Serialize(file, arraySocer);
        file.Close();
    }

    //đọc file điểm
    public player_data read_data()
    {
        ArrayList ps = new ArrayList();
        if (File.Exists(Application.persistentDataPath + "/" + file_name))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + file_name, FileMode.Open);
            ps = (ArrayList)bf.Deserialize(file);
            file.Close();
            return (player_data)ps[0];
        }
        else
        {
            return new player_data();
        }
    }
}