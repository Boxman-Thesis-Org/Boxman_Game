/* The code is from Brackey's Save tutorial 
https://www.youtube.com/watch?v=XOjd_qU2Ido&list=RDCMUCYbK_tjZ2OrIZFBvU6CCMiA&start_radio=1&t=961s&ab_channel=Brackeys
And the comments are my own */

using UnityEngine;

/*System.IO is used whenever you wish to engage with the operating system
This will be used to create the save file */

/*System.Runtime.etc is used to access a binary formatter for 
compiling purposes */

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*This isn't going to be attached to any game object as a component, nor 
will it use any of the standard Unity methods, so the Monobehavior base
class doesn't need to be called */

/* This file is made static, so multiple instances aren't created of the
save system */

public static class SaveSystem{

/* for this method, use void, because you aren't returning anything
you're just reading and conveying data to a file stream */
public static void SavePlayer (Player player)
    {
    //creates a binary formatter for the data
    BinaryFormatter formatter = new BinaryFormatter();
    /*uses a unity function that finds a path to data directory
    on whatever operating system is running your project */
    string path = Application.persistentDataPath + "/player.save";
    //Create a file on the system to capture the stream of data 
    FileStream stream = new FileStream(path, FileMode.Create);

    /*runs all of the PlayerData code to capture up-to-date
    information on the player's health and position */
    PlayerData data = new PlayerData(player);
    Debug.Log("Health: " + data.health);
    Debug.Log("PosX: " + data.position[0]);
    Debug.Log("PosY: " + data.position[1]);
    Debug.Log("PosZ: " + data.position[2]);
    /*formatter.Serialize write data to the file, so we call the
    PlayerData data and convey it through the file stream for
    serialization */
    formatter.Serialize(stream, data);
    stream.Close();
    }

public static PlayerData LoadPlayer()
    {
    string path = Application.persistentDataPath + "/player.save";

    //Checking for the player's save file
    if(File.Exists(path))
        {
         /* Opening a binary formatter, this time 
         to translate FROM binary */
         BinaryFormatter formatter = new BinaryFormatter();

         /* Calling file stream, this time you use FileMode.Open 
        instead of FileMode.Create. This is because you're opening an
        existing file stream that you created when saving */ 

        FileStream stream = new FileStream(path,FileMode.Open);

        /*formatter.Deserialize is what tells the binary formatter to 
        translate your data from binary to C# */

        /*PlayerData data is the component variable that acts as a container
         to recieve all of this incoming data */
        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();
        Debug.Log("Load Health: " + data.health);
        Debug.Log("Load PosX: " + data.position[0]);
        Debug.Log("Load PosY: " + data.position[1]);
        Debug.Log("Load PosZ: " + data.position[2]);

        BoxmanHealth.boxmanHealth = data.health;
        Player.currVector.x = data.position[0];
        Player.currVector.y = data.position[1];

        } 
    else
        {
         Debug.LogError("Save file not found in" + path);
        return null;
        }

     // this is added to avoid an error about not finding player data
     //found the solution here: https://stackoverflow.com/questions/36257249/not-all-code-paths-return-a-value-unity
    return null;
    }

}
