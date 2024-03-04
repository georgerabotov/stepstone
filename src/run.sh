echo ---Start---
docker build -t stepstone . 
echo ---Building---
winpty docker run -it --rm -p 5000:5000 -e ASPNETCORE_URLS=http://+:5000 --name stepstone_sample stepstone -bash
echo ---Running Container---