# Docker-Compose starter projekt

Här finns start koden för docker compose genomgången.
Applikationen är ett REST API byggt med Node.js
Som kopplar sig mot en container baserad mongodb databas.

## Instruktioner

1. Hämta hem koden och navigera in i katalogen simple-node-api.
2. Öppna upp VS Code's terminal fönster och se till att använda Bash. Kör kommandot `npm install`för att installera alla beroenden.

### Installera/hämta mongodb's image

Vi använder mongodb's officiella image på Docker Hub.
För att skapa en container för mongodb kör följande kommando i VS Code's terminal fönster:
`docker run --n mongodb --rm -d -p 27017:2017 mongo`

### Skapa en image för vårt node.js api

**Se till att vara i katalogen simple-node-api!**
För att skapa en image av vårt REST API skriv följande kommando i VS Code's terminal fönster:
`docker build -t backend-api .`

### Skapa en container för vårt REST API

I VS Code's terminal fönster skriv följande kommando:

`docker run --name backend --rm -d -p 80:80 backend-api`

### Testa applikationen

I en webbläsare eller allra bäst i t ex Postman skapa ett GET anrop och skriv in adressen http://localhost:80/api/vehicles.
Om allt går bra ska vi se ett json dokument med success:true och data som en tom array [].
