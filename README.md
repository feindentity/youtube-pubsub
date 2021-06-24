# youtube-pubsub
For Sub
dapr run -a sub -p 3501 -d ..\..\components\ -- dotnet run -urls http://*:3501

For Pub
dapr run -a pub -p 3500 -d ..\..\components\ -- dotnet run
