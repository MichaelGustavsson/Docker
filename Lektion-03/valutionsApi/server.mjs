import express from 'express';
import cors from 'cors';

const app = express();

app.use(express.json());
app.use(cors());

app.get('/', (req, res) => {
  res.status(200).json({ success: true, data: valuations });
});

app.post('/', (req, res) => {
  const valuation = {
    valuationId: valuations.length + 1,
    message: 'The vehicle is registrered for valuation',
    vehicle: req.body.vehicle,
  };

  valuations.push(valuation);
  res.status(201).json({ success: true, data: valuation });
});

const PORT = process.env.PORT || 3001;

app.listen(PORT, () =>
  console.log(`Valuation server is running on port: ${PORT}`)
);

// Demo data...
const valuations = [];
