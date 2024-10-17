import express from 'express';
import Movie from './models/Movie.mjs';
import connectDb from './config/db.mjs';

connectDb();
const app = express();

app.use(express.json());

app.get('/api/favorites', async (req, res) => {
  const movies = await Movie.find();
  res.status(200).json({ success: true, data: movies });
});

app.post('/api/favorites', async (req, res) => {
  const name = req.body.name;
  const imageUrl = req.body.imageUrl;

  try {
    const movie = new Movie({
      name,
      imageUrl,
    });

    await movie.save();

    res.status(201).json({ success: true, data: movie.toObject() });
  } catch (error) {
    console.log(error);
  }
});

app.get('/api/movies', async (req, res) => {
  const url = '';

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
