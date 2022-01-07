# Codewars-Slack-bot

## Introduction
Codewars Slack bot is a C# application that communicates with the Codewars API and Slack API to provide statistics and notifications to your friends/collegues via Slack.

## Usage
In its current state, the bot only reports the current standing of a given collection of users from a JSON file and it also does this on execution. This means it will have to be run as a scheduled task on Windows machines if it was to post the leaderboard on a specific day/time e.g. Every Monday at 9:00.

Additionally, you will need to register the bot as a Slack App in your own workspace here: https://api.slack.com/apps?new_app=1. From there, turn on Incoming Webhooks and set the property 'SlackWebHookDetailsUrl' in the App.config file to the one of your webhook.

E.g. If your webhook was: https://hooks.slack.com/services/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, then you would set 'SlackWebHookDetailsUrl' to: '/T02T116NZTM/B02TQNED7U0/8kvEzRyUjtXQSP6No9CeRUAV'
     
![image](https://user-images.githubusercontent.com/8987004/148583293-d8f118bc-4feb-4045-b216-2c86a3cc760b.png)


## References
Codewars API - https://dev.codewars.com/#introduction

Slack API - https://api.slack.com/docs
