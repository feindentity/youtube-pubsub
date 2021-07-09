# youtube-pubsub
# Install for codespaces for this space
wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash
#don't forget to run 'dapr init'
dapr init

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


# Notes for Kubernetes
	1. Install Chocolaty
	2. Install Minikube
	3. Install Dapr
	4. Install Helm
	5. Install Docker
	6. Init MiniKube
	7. Init Dapr In Minikube  -k
	8. Helm in Redis
		helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo update
helm install redis bitnami/redis
		
		From <https://docs.dapr.io/getting-started/configure-state-pubsub/> 
	9. Deploy PubSub and State to Kubernetes
		a. Kubectl apply -f .\remote-redis-pubsub.yaml
		b. Kubectl apply -f .\remote-redis-state.yaml
	
Updating DAPR settings require a pod restart from initial findings
You can use kubectl rollout restart deployment to kill and restart a new node. 
kubectl rollout restart deployment python-subscriber
To restart start deployed pod

Inspect a container, using podname
kubectl exec -it redis-replicas-1 -- bash
NG5GODJIdTRuZA==
4nF82Hu4nd

Tools for Troubleshooting
Dapr Kubernetes pod annotations spec | Dapr Docs



	
