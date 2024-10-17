import express from 'express';

const app = express();

app.get('/', (req, res) => {
  res.send(`
    <html>
      <head>
        <title>Dockerized node app</title>
      </head>
      <body>
        <main>
          <h1>Detta är en enkel applikation</h1>
        </main>
      </body>
    </html>
    `);
});

app.listen(5001);
