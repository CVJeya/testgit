1. Open the solution file under the src/helloapp folder and compile the dockerfile
2. Run the container giving the port address as 5000 from the Docker Client and run the container to see the output in http://localhost:5000

3. Similarly go into the helloapi folder and build the solution and build the docker image. Then run the container from Visual Studio. View the  output from http://localhost:49155/swagger/index.html. Here the docker is running the api in development mode.

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