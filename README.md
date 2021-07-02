# youtube-pubsub
# Install for codespaces for this space
wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash -s 1.0.0-rc.2

# For Sub
dapr run -a sub -p 3501 -d ..\..\components\ -- dotnet run -urls http://*:3501

# For Codespaces
dapr run --app-id sub -p 3501 -d ../../components -- dotnet run -urls http://*:3501

dapr run --app-id sub -p 3502 -d ../../components -- dotnet run -urls http://*:3502
# For Pub
dapr run -a pub -p 3500 -d ..\..\components\ -- dotnet run
# For CodeSpaces
dapr run --app-id pub -p 3500 -d ../../components -- dotnet run

# view data for redis
docker ps
docker exec -it 2ff6628ce0c5 redis-cli
Xread COUNT 50 STREAMS above-store-user 0