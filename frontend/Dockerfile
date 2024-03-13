FROM node:20.11-alpine

WORKDIR /app

COPY package.json ./

RUN npm install --production --loglevel=error

COPY ./ ./

RUN npm run build

EXPOSE 3000

USER node

CMD [ "npm", "start" ]