import express, { json } from 'express';
import cors from 'cors';

const app = express();

app.use(express.json());
app.use(cors());

app.get('/', (req, res) => {
  res.status(200).json({ success: true, data: vehicles });
});

app.post('/', async (req, res) => {
  const url = 'https://azure-valutions-api.azurewebsites.net/';
  // const url = 'http://localhost:3001/';
  vehicles.push(req.body);
  // Send vehicle to valuationservice...
  try {
    const vehicle = {
      vehicle: req.body,
    };

    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(vehicle),
    });

    const valuation = await response.json();
    res.status(201).json({ success: true, data: valuation });
    return;
  } catch (error) {
    res.status(500).json({ success: false, message: error });
    return;
  }
});

const PORT = process.env.PORT || 3000;

app.listen(PORT, () => console.log(`Server is running on port: ${PORT}`));

const vehicles = [
  {
    regNumber: 'ABC123',
    manufacturer: 'Volvo',
    model: 'XC60',
    modelYear: 2018,
  },
  {
    regNumber: 'DEF123',
    manufacturer: 'Ford',
    model: 'Mustang MACH-E',
    modelYear: 2022,
  },
  {
    regNumber: 'GHI123',
    manufacturer: 'KIA',
    model: 'Ceed',
    modelYear: 2020,
  },
];
