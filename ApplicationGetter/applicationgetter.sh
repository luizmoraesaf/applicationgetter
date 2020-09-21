#!/bin/bash
DOCKERPULL=`docker pull luizmoraesaf/applicationgetter:latest`
if [[ $DOCKERPULL != *"Status: Image is up to date for"* || $1 == '/f' ]]; then
        echo "Updating"
        docker stop appgetter-backend
        docker rm appgetter-backend
        docker run -p 8000:80 \
                -d \
                --name appgetter-backend \
                luizmoraesaf/applicationgetter:latest
else
        echo "Image is already updated"
fi