# AlexaSkill_AzureFunction
This Azure function will allow you to interact with your bot using Alexa. 
```
dotnet add package Alexa.NET
```

### To Run the Azure Function locally: 
Add the URL and Headers to local.Settings.json and ensure that the Nuget package Alexa.NET is installed. 
```
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "",
        "HeaderName": "", 
        "HeaderValue": "",
        "Url": "",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
    }
}
```
## Quick Deploy to Azure

[![Deploy to Azure](http://azuredeploy.net/deploybutton.svg)](https://azuredeploy.net/)

### To Create an Alexa Skill 
Follow [this blog post](https://blogs.msdn.microsoft.com/appconsult/2018/11/02/build-your-first-alexa-skill-with-alexa-net-and-azure-functions-the-basics/)

If you do not want to specify a sample utterness, and would like to take in all of the user input this is a workaround:
Navigate to the JSON editor and paste the following: The key thing when defining slot type values is to have sentences with always one word more than the previous. otherwise, it won't catch the whole sentence. 
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
