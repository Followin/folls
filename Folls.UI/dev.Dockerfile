FROM node:alpine
WORKDIR /app

COPY ./fe/package*.json ./
RUN npm install

ENTRYPOINT ["npm", "run", "serve"]