1.  go into the ReactSPA folder and start the application right clicking the dockerfile and building the image
2. Connects React front end with webapi backend
Key Takeaways
docker-compose up --build 
is used to build the docker images for api and app and run the container

docker system prune -a --volumes
is used to remove all unused containers, volumes, networks and images


Running the application using https is not advisable, since pfx copying is not easy with the help of docker. instead k8s helm can be used.
To generate certificates run these two commands and add env in secretsjson
dotnet dev-certs https --clean
dotnet dev-certs https --trust -ep %USERPROFILE%\.aspnet\https\employeeapi.pfx -p employeeapi23
dotnet dev-certs https --trust

copy the pfx file to the project root location