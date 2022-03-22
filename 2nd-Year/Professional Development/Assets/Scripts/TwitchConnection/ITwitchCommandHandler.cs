using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITwitchCommandHandler
{
    void HandleCommmand(TwitchCommandData data);
}

public struct TwitchCommandData {
    public string Author;
    public string Message;
}

public struct TwitchCredentials {
    public string ChannelName;
    public string Username;
    public string Password;
}

public static class TwitchCommands {
    public static readonly string CmdPrefix = "!";
    public static readonly string CmdMessage = "message";

    public static readonly string CmdVoteOne = "One";
    public static readonly string CmdVoteTwo = "Two";
    public static readonly string CmdVoteThree = "Three";

    public static readonly string CmdRNGEquip = "Equip";
    public static readonly string CmdRNGJam = "Jam";

    public static readonly string Cmdscout = "Scout";
    public static readonly string Cmdengineer = "Engineer";
    public static readonly string Cmdmedic = "Medic";
    public static readonly string Cmdsoldier = "Soldier";
    public static readonly string Cmdjanitor = "Janitor";

    public static readonly string CmdYeet = "Yeet";
}

// EXAMPLES - This is how I would impletement this interface and create classes with actual command logic

// !message command
public class TwitchDisplayMessageCommand : ITwitchCommandHandler {
    public void HandleCommmand(TwitchCommandData data){
        Debug.Log($"<color=cyan>Raw Message:{data.Message}</color>");

        // strip the !message command from the message and trim the leading whitespace
        string actualMessage = data.Message.Substring(0 + (TwitchCommands.CmdPrefix + TwitchCommands.CmdMessage).Length).TrimStart(' ');
        Debug.Log($"<color=cyan>{data.Author} says {actualMessage}</color>");
    }
}

//TWITCH VOTE OPTIONS

public class TwitchVoteOneCommand : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        LevelVoteBox.Instance.AddVoteOne(1);
    }
}

public class TwitchVoteTwoCommand : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        LevelVoteBox.Instance.AddVoteTwo(1);
    }
}

public class TwitchVoteThreeCommand : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        LevelVoteBox.Instance.AddVoteThree(1);
    }
}

//RANDOM EVENTS
public class TwitchRNGEquip : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        RandomEvent._instance.EquipRandom();
        RandomEvent._instance.WeaponLockTextUser.text = "By: " + data.Author;

    }
}

public class TwitchRNGJam : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        RandomEvent._instance.JamWeaponRandom();
        RandomEvent._instance.WeaponJamTextUser.text = "By: " + data.Author;
    }
}

//TWITCH CHOOSING CLASSES

public class TwitchJanitor : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        PlayerClass.instance.JanitorInt();
    }
}

public class TwitchMedic : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        PlayerClass.instance.MedicInt();
    }
}

public class TwitchEngineer : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        PlayerClass.instance.EngineerInt();
    }
}

public class TwitchScout : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        PlayerClass.instance.ScoutInt();
    }
}

public class TwitchSoldier : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        PlayerClass.instance.SoldierInt();
    }
}

//dev troll

public class TwitchYeet : ITwitchCommandHandler
{
    public void HandleCommmand(TwitchCommandData data)
    {
        RandomEvent._instance.Yeet();
    }
}
public class CommandCollection {

    private Dictionary<string, ITwitchCommandHandler> _commands;

    public CommandCollection(){
        _commands = new Dictionary<string, ITwitchCommandHandler>();
        _commands.Add(TwitchCommands.CmdMessage, new TwitchDisplayMessageCommand());

        //vote
        _commands.Add(TwitchCommands.CmdVoteOne, new TwitchVoteOneCommand());
        _commands.Add(TwitchCommands.CmdVoteTwo, new TwitchVoteTwoCommand());
        _commands.Add(TwitchCommands.CmdVoteThree, new TwitchVoteThreeCommand());

        //rng
        _commands.Add(TwitchCommands.CmdRNGEquip, new TwitchRNGEquip());
        _commands.Add(TwitchCommands.CmdRNGJam, new TwitchRNGJam());

        //class
        _commands.Add(TwitchCommands.Cmdjanitor, new TwitchJanitor());
        _commands.Add(TwitchCommands.Cmdmedic, new TwitchMedic());
        _commands.Add(TwitchCommands.Cmdengineer, new TwitchEngineer());
        _commands.Add(TwitchCommands.Cmdscout, new TwitchScout());
        _commands.Add(TwitchCommands.Cmdsoldier, new TwitchSoldier());

        //dev troll

        _commands.Add(TwitchCommands.CmdYeet, new TwitchYeet());
    }

    public bool HasCommand(string command){
        return _commands.ContainsKey(command) ? true : false;
    }

    public void ExecuteCommand(string command, TwitchCommandData data){
        command = command.Substring(1); // remove exclamation point
        if(HasCommand(command)){
            _commands[command].HandleCommmand(data);
        }
    }
}


