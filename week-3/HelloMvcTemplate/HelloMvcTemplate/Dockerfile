# Dockerfile is a list of instructions for how to build a new image
# from a baseline of some already existing image.

# most basic sort of dockerfile:

# choose a base image with the dependencies for the thing you're going to copy in
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# sets the current working directory,
# creates it if it doesn't already exist
WORKDIR /app/src

# copy that thing in
COPY *.csproj ./
RUN dotnet restore

COPY . ./

# this runs during "docker build"
RUN dotnet publish -o ../publish

ENV ASPNETCORE_URLS http://*:80

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish ./

# configure it with the command it will use to start containers
# this runs at the start of "docker run"
ENTRYPOINT ["dotnet", "publish/HelloMvcTemplate.dll"]

# usage
#   docker build -t docker-console .
#   docker run docker-console