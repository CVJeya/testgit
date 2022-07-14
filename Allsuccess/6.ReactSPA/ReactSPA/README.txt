Key Takeaways


docker system prune -a --volumes
is used to remove all unused containers, volumes, networks and images


To Execute the project :
1. Clear the unused containers.
2. Right click the Dockerfile from Solution Explorer and build the image
3. docker run -p 5000:80 reactspa:latest 
4. Open http://localhost:5000/
Thus React Web Application is connected with an asp.net web api and is packaged successfully.

References :
https://docs.microsoft.com/en-us/visualstudio/containers/container-tools-react?view=vs-2022
https://medium.com/@mustafamagdy1/netcore-react-docker-1d19f051942c
