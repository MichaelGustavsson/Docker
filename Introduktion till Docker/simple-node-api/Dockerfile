# STEG 1.
# Hämta en bas image för node
# Om den finns lokalt så används den annars hämtas en officiell image...
FROM node

# STEG 2.
# Skapa en arbetskatalog dvs vilken katalog ska 
# användas för alla kommandon som vi kommer att köra
# I containern som kommer att exekvera vår image
WORKDIR /app

# STEG 3.
# Vilka filer i vårt projekt ska vår images innehålla...
COPY . /app

# STEG 4.
# Installera alla beroende (package.json)
RUN npm install

# STEG 5. (Valfritt)
# Rekommenderat för dokumentationen
EXPOSE 5001

# STEG 6.
# Nu vill vi starta vårt node REST API varje gång vår container startar.
CMD [ "node", "server.mjs" ]
