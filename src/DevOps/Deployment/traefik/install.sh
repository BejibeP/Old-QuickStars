#!/bin/sh
echo "Installing Traefik..."

if ! [ -d "./data" ] 
then
    echo "Creating data folder"
    mkdir data 
fi

if ! [ -f "./data/acme.json" ] 
then
    echo "Creating cert storage file"
    touch ./data/acme.json
    chmod 600 ./data/acme.json 
fi

echo "Installing traefik config file"
mv ./traefik.toml ./data/traefik.toml

NETWORK_PROXY=proxy
if [ -z $(docker network ls --filter name=^${NETWORK_PROXY}$ --format="{{ .Name }}") ]
then 
    echo "Creating docker network PROXY"
    docker network create ${NETWORK_PROXY} ; 
fi

echo "Starting traefik..."
docker compose up -d 

echo "Removing Installer..."
rm -rf ./install.sh