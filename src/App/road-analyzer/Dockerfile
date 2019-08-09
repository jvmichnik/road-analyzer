# base image
FROM node:12.2.0-alpine

RUN npm install nodemon -g
WORKDIR /app
ADD . /app
RUN npm install
EXPOSE 3000
CMD ["npm", "start"] 