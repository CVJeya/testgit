# testgit
# Testing from CV computer to GITHUB
# Included read me and composer default file and given MIT as the license

# GIT Instructions Used:

### whoami
### pwd 
### ls -l 
### ls -F 
### git config --global user.name "Test Git"
### git config user.email "xxx@xxx.com"
### git init 
### git add .
### git commit -m "Message"
### git remote add origin https://github.com/CVJeya/testgit.git 
### If not working,
### git remote set-url origin https://github.com/CVJeya/testgit.git
### git push origin master

## Inorder to merge a feature branch to a master branch do the following
### 1. git checkout master  - Change the current working branch as master
### 2. git pull - Fetch the recent code
### 3. git merge origin/azure-pipelines --allow-unrelated-histories     - Merge a feature branch to the master branch allowing unrelated histories
### 4. git push origin master

## Inorder to get the latest changes in the master branch of remote repository do the following
### git pull origin master To fetch the updated repository to local repository for the branch master

# Docker Commands

### docker login
### Log in to a Docker registry
### Usage :
$ docker login [OPTIONS] [SERVER]
Example:
$ docker login localhost:8080

### docker build 
### Build an image from a Dockerfile
### Usage :
$ docker build [OPTIONS] PATH | URL | -

Example :
$ docker build -t simpleapi .

### docker images
### List images
###  Usage :
$ docker images [OPTIONS] [REPOSITORY[:TAG]]
Example :
$ docker images

### docker logout
Log out from a Docker registry
Usage :
$ docker logout [SERVER]
Example:
$ docker logout localhost:8080


### docker tag
Create a tag TARGET_IMAGE that refers to SOURCE_IMAGE
Usage :
$ docker tag SOURCE_IMAGE[:TAG] TARGET_IMAGE[:TAG]
Example :
$ docker tag simpleapi xxx23/simpleapi

### docker ps
List containers
Usage :
$  docker ps [OPTIONS]

Example :
$ docker ps

### docker run
Run a command in a new container
Usage :
$ docker run [OPTIONS] IMAGE [COMMAND] [ARG...]

Example:
$  docker run -it --rm -p 8080:80 --name mycontainer xxx23/simpleapi

### docker push
Usage :
$ docker push [OPTIONS] NAME[:TAG]

Example:
$  docker push xxx23/simpleapi

### docker pull
Pull an image or a repository from a registry
Usage :
$ docker pull [OPTIONS] NAME[:TAG|@DIGEST]

Example:
$  docker pull xxx23/simpleapi

# Demo 1 - Run a docker image in 3 different containers

### 1.msdockerapp\..\helloapp. Create docker image and then run the docker image helloapp:latest  of the hello world application inside three containers with container port 80 mapped to the host ports 8000, 8001, and 8002. Use 3 different terminals to start the containers and open in browser


$ docker run -p 8000:80 helloapp:latest

$ docker run -p 8001:80 helloapp:latest

$ docker run -p 8002:80 helloapp:latest



# Demo 2 – Only authorised user can access a private docker repository and combine two services using docker-compose

### 2.mslearn-dotnetmicroservices. Create docker images for frontend and backend separately and push it to private repository

$ docker build -t helloworld:frontend .
$ docker tag helloworld:frontend xxx/helloworld:frontend

$ docker push xxx/helloworld:frontend

$ docker build -t helloworld:backend .
$ docker tag helloworld:backend xxx/helloworld:backend

$ docker push xxx/helloworld:backend

# Above commands are done need to give only the below command and it works only for authorised users
### $ docker-compose up --build 


# Use this docker command to delete everything:
## docker system prune -a --volumes
### Remove all unused containers, volumes, networks and images
##  WARNING! This will remove:
###   - all stopped containers
###   - all networks not used by at least one container
###   - all volumes not used by at least one container
###   - all images without at least one container associated to them
###   - all build cache

# Some Docker Swarm Commands

docker swarm init --advertise-addr 192.168.99.121

docker exec -it busybox.1 /bin/sh

docker service create --name my_web --replicas 3 --publish 8080:80 nginx


docker service inspect my_web

docker service ls

docker network ls

docker images hello-world
docker run -d -p 5000:80 --name employeeapi my-api-app

docker run -d -p 5000:80 --name my-hello-app hello-world:latest 

docker exec -it busybox /bin/sh

# Kubernetes Commands :

kubectl version --client
kubectl cluster-info
kubectl get nodes

kubectl create deployment first-deployment --image=katacoda/docker-http-server

kubectl create deployment firsthello-deployment --image=hello-world:latest --replicas=1
kubectl get deployments
kubectl get events
kubectl describe deployment first-deployment

kubectl delete deployment first-deployment
kubectl get rs
kubectl get pods -o wide

To run the dashboard yaml
kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.5.0/aio/deploy/recommended.yaml

1.Create Admin Service Account
Creating admin user to access Kubernetes dashboard:
$ kubectl apply -f dashboard-adminuser.yml
serviceaccount/admin-user created

2. Create ClusterRoleBinding
$ kubectl apply -f admin-role-binding.yml
clusterrolebinding.rbac.authorization.k8s.io/admin-user created

3. Get Token

Now we’re ready to get the token from admin-user by following command.

kubectl -n kube-system describe secret $(kubectl -n kube-system get secret | grep admin-user | awk '{print $1}')



kubectl proxy

kubectl proxy --port=8080
curl http://localhost:8080/api/

Kubectl will make Dashboard available at http://localhost:8001/api/v1/namespaces/kubernetes-dashboard/services/https:kubernetes-dashboard:/proxy/.


References : https://medium.com/@kanrangsan/creating-admin-user-to-access-kubernetes-dashboard-723d6c9764e4

> kubectl create deployment -h
Create a deployment with the specified name.

Aliases:
deployment, deploy

Examples:
  # Create a deployment named my-dep that runs the busybox image
  kubectl create deployment my-dep --image=busybox

  # Create a deployment with a command
  kubectl create deployment my-dep --image=busybox -- date

  # Create a deployment named my-dep that runs the nginx image with 3 replicas
  kubectl create deployment my-dep-nginx --image=nginx --replicas=3

  # Create a deployment named my-dep that runs the busybox image and expose port 5701
  kubectl create deployment my-dep --image=busybox --port=5701

Options:
      --allow-missing-template-keys=true: If true, ignore any errors in templates when a field or map key is missing in
the template. Only applies to golang and jsonpath output formats.
      --dry-run='none': Must be "none", "server", or "client". If client strategy, only print the object that would be
sent, without sending it. If server strategy, submit server-side request without persisting the resource.
      --field-manager='kubectl-create': Name of the manager used to track field ownership.
      --image=[]: Image names to run.
  -o, --output='': Output format. One of:
      --port=-1: The port that this container exposes.
      --save-config=false: If true, the configuration of current object will be saved in its annotation. Otherwise, the
annotation will be unchanged. This flag is useful when you want to perform kubectl apply on this object in the future.
      --template='': Template string or path to template file to use when -o=go-template, -o=go-template-file. The
template format is golang templates [http://golang.org/pkg/text/template/#pkg-overview].

Usage:
  kubectl create deployment NAME --image=image -- [COMMAND] [args...] [options]

Use "kubectl options" for a list of global command-line options (applies to all commands).


# vim editor:
Esc
:wq : after saving
:q! : without saving


# To run Postgres in container :
The First command you will fire from your ubuntu terminal
sudo -i -u postgres
Then you can fire command
psql
to go into postgres console.
Then you can create database.
CREATE DATABASE mydb
