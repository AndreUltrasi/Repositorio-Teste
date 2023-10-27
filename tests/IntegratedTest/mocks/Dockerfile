FROM node:12-alpine
RUN mkdir /app
WORKDIR /app
COPY ./mocks/package.json /app
RUN npm install
COPY ./mocks/* /app/
EXPOSE 3010
CMD ["npm", "start"]

