// Importera express ifrån biblioteket express
// Motsvara using i C#...
import express from 'express';
import mongoose from 'mongoose';
import cors from 'cors';
import connectDb from './config/db.mjs';
import Vehicle from './models/Vehicle.mjs';

// Skapa applikation
const app = express();

app.use(express.json());
app.use(cors());

app.get('/api/vehicles', async (req, res) => {
  console.log('Fetching vehicles');
  const vehicles = await Vehicle.find();
  res.status(200).json({ success: true, data: vehicles });
});

app.post('/api/vehicles', async (req, res) => {
  console.log('Adding a new vehicle');
  const { manufacturer, model } = req.body;

  const vehicle = new Vehicle({
    manufacturer,
    model,
  });

  try {
    await vehicle.save();
    res.status(201).json({ success: true, data: vehicle });
  } catch (error) {
    console.log('Error adding vehicle');
    console.log(error);
    res
      .status(500)
      .json({ success: false, message: 'Failed to add a new vehicle' });
  }
});
// Anslut till mongodb...
connectDb();

const server = app.listen(80, () => {
  console.log(`Server started on 80`);
});

process.on('unhandledRejection', (err, promise) => {
  console.log(err.name, err.message);
  server.close(() => process.exit(1));
});
