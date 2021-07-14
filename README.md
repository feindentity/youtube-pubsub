# Local Setup 
## For subscribers\sub
	dapr run -a sub -p 3313 -d ..\..\components\ -- dotnet run -urls http://*:3313
## For publishers\user-publisher 
	dapr run -a pub -p 3303 -d ..\..\components\ -- dotnet run

## view data for redis set
1. Look up container id	
		docker ps -f name=redis
	
		CONTAINER ID   IMAGE     COMMAND                  CREATED       STATUS       PORTS                                       NAMES
		2d94138d64d0   redis     "docker-entrypoint.s…"   3 weeks ago   Up 4 hours   0.0.0.0:6379->6379/tcp, :::6379->6379/tcp   dapr_redis

2. use container id to access redis container cli
   
		docker exec -it 2d94138d64d0 redis-cli
   
3. Read your topic stream
	
		Xread COUNT 50 STREAMS above-store-user 0

# For Codespaces Setup
## Install dapr for codespaces for this space
	
	wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash
	#don't forget to run 'dapr init'
	dapr init

## For SubScriber
	dapr run --app-id sub -p 3313 -d ../../components -- dotnet run -urls http://*:3313

## For Pub
dapr run --app-id pub -p 3500 -d ../../components -- dotnet run


# for Kubernetes setup
## SETUP
1. Install Chocolaty
2. Install Minikube
3. Install Dapr
4. Install Helm
5. Install Docker
6. Init MiniKube
7. Init Dapr for cluster
		dapr init -k
8. Use Helm to install Redis

		helm repo add bitnami https://charts.bitnami.com/bitnami
		helm repo update
		helm install redis bitnami/redis


9. Deploy PubSub and State to Kubernetes in /deploy
	

		Kubectl apply -f .\remote-redis-pubsub.yaml
		Kubectl apply -f .\remote-redis-state.yaml
	

    
look up 
Inspect a container, using podname

## View Redis Setup 
		kubectl exec -it redis-replicas-1 -- redis-cli
		# Authenticate with redis password for cluster
		AUTH 4nF82Hu4nd
		# Lookup Topic
		Xread COUNT 50 STREAMS above-store-user 0
		# Delete Topic
		delete above-store-user

## Tools for Troubleshooting dapr and kubernetes
- Updating DAPR settings require a pod restart from initial findings

		#Example of restarting a pod
		kubectl rollout restart deployment python-subscriber

- [Dapr Common Issues](https://docs.dapr.io/operations/troubleshooting/common_issues/)
- [Dapr Kubernetes pod annotations spec | Dapr Docs](https://docs.dapr.io/operations/hosting/kubernetes/kubernetes-annotations/)
- [Adding Debugging for working with DAPR in VSCode](https://docs.dapr.io/developing-applications/ides/vscode/#manually-configuring-visual-studio-code-for-debugging-with-daprd)




	
