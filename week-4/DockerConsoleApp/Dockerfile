# Dockerfile is a list of instructions for how to build a new image
# from a baseline of some already existing image.

# most basic sort of dockerfile:

# choose a base image with the dependencies for the thing you're going to copy in
FROM mcr.microsoft.com/dotnet/sdk:5.0

# sets the current working directory,
# creates it if it doesn't already exist
WORKDIR /app

# copy that thing in
COPY . ./

# this runs during "docker build"
RUN dotnet publish -o publish

# FROM mcr.microsoft.com/dotnet/runtime:5.0

# configure it with the command it will use to start containers
# this runs at the start of "docker run"
CMD dotnet publish/DockerConsoleApp.dll

# usage
#   docker build -t docker-console .
#   docker run docker-console