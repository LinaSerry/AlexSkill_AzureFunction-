# AlexaSkill_AzureFunction

#Create an Alexa Skill 
Follow [this blog post](https://blogs.msdn.microsoft.com/appconsult/2018/11/02/build-your-first-alexa-skill-with-alexa-net-and-azure-functions-the-basics/)

If you do not want to specify a sample utterness, and would like to take in all of the user input this is a workaround: 
```
{
    "interactionModel": {
        "languageModel": {
            "invocationName": "my bot",
            "intents": [
                {
                    "name": "AMAZON.FallbackIntent",
                    "samples": []
                },
                {
                    "name": "AMAZON.CancelIntent",
                    "samples": []
                },
                {
                    "name": "AMAZON.HelpIntent",
                    "samples": []
                },
                {
                    "name": "AMAZON.StopIntent",
                    "samples": []
                },
                {
                    "name": "AMAZON.NavigateHomeIntent",
                    "samples": []
                },
                {
                    "name": "catch_all",
                    "slots": [
                        {
                            "name": "any",
                            "type": "ANYTHING"
                        }
                    ],
                    "samples": [
                        "{any}"
                    ]
                }
            ],
            "types": [
                {
                    "name": "ANYTHING",
                    "values": [
                        {
                            "name": {
                                "value": "any any any any any any any any any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any any any any any any any any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any any any any any any any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any any any any any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any any any any any "
                            }
                        },
                        {
                            "name": {
                                "value": "any any any any any any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any any any "
                            }
                        },
                        {
                            "name": {
                                "value": "any any any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any any"
                            }
                        },
                        {
                            "name": {
                                "value": "any"
                            }
                        }
                    ]
                }
            ]
        }
    }
}
```
