import express from 'express';

const app = express();

app.use(express.json());

app.get('/api/movies', async (req, res) => {
  const url =
    'https://api.themoviedb.org/3/movie/popular?api_key=fc5bab87a5b775a9620a4ab4294d84f3&language=sv-SE';

  try {
    const response = await fetch(url);
    if (response.ok) {
      const result = await response.json();
      console.log(result);
      res.status(200).json({ success: true, data: result });
    }
  } catch (error) {
    console.log(error);
  }
});

app.listen(5001);
