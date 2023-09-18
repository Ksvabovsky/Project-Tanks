using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;

public class DiscordManager : MonoBehaviour
{
    Discord.Discord discord;

    string Details = "Projekt w unity";
    string State = "kiedys go zrobie";
    string LargeImage = "ja-osmiornica";
    string LargeText = "Paker jest boski";
    string SmallImage = null;
    string SmallText = null;
    long TimeStamp;

    public static DiscordManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        discord = new Discord.Discord(1147860869036920862, (long)CreateFlags.Default);

        UpdateRichPresence(updateTimeStamp: true);
    }

    public void UpdateRichPresence(string details = null, string state = null, string largeImage = null ,string largeText = null, string smallImage = null,string smallText = null, bool updateTimeStamp = false)
    {
        Details = details ?? Details;
        State = state ?? State;
        LargeImage = largeImage ?? LargeImage;
        LargeText = largeText ?? LargeText;
        SmallImage = smallImage ?? SmallImage;
        SmallText = smallText ?? SmallText;
        TimeStamp = updateTimeStamp ? (new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() - 5000) : TimeStamp;

        ActivityManager activityManager = discord.GetActivityManager();
        Activity activity = new()
        {
            Details = Details,
            State = State,
            Assets =
            {
                LargeImage = LargeImage,
                LargeText = LargeText,
                SmallImage = SmallImage,
                SmallText = SmallText
            },
            Timestamps = {
                Start = TimeStamp
            }
        };

        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Result.Ok)
            {
                Debug.Log("Ustawiono DSC");
            }
            else
            {
                Debug.LogError("Chuj");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }

    private void OnDisable()
    {
        discord.Dispose();
    }
}
