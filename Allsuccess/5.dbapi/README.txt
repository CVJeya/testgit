Key Takeaways
docker-compose up --build 
is used to build the docker images for api and app and run the container

docker system prune -a --volumes
is used to remove all unused containers, volumes, networks and images

PS D:\Workings\Docker\dbapi\employee.api> docker-compose up --build
to run the container after building the image
1. Connected using Docker with DB instance locally
2. Migration will be done automatically using docker
3. Seeded data to Employee Table with dummy data
4. Environment variables are given input through docker-compose.yaml 
for ServerName, Database, UserName and Password
5. Add, Get , Dispose functions are available in Repository
6. Layering in code :
Data Access Layer. Repository
Employee.Provider.Contracts

Login to DB us

with 
Servername : localhost
User : sa
PW :


To Execute the project :
1. Clear the containers.
2. From command prompt build the image using docker compose up --build.
3. Once step 2 is completed successfully Connect with the database snapshot locally
4. Check the database.
5. Database will be created. Table will be seeded. Port will be mapped
6. Restart the api if needed checking the status of the container.
7. Check the output using the link http://localhost/api/employee/GetEmployees
 from explorer or through postman.
Thus mssqlserver databaseis connected with an asp.net web api and is packaged successfully.

Running the application using https is not advisable, since pfx copying is not easy with the help of docker. instead k8s helm can be used.
To generate certificates run these two commands and add env in secretsjson
dotnet dev-certs https --clean
dotnet dev-certs https --trust -ep %USERPROFILE%\.aspnet\https\employeeapi.pfx -p employeeapi23
dotnet dev-certs https --trust

copy the pfx file to the project root location