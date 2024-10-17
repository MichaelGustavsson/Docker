// Importera express ifrån biblioteket express
// Motsvara using i C#...
import express from 'express';

// Skapa applikation
const app = express();

// Skapa lite dummy data...
const products = [
  {
    id: 1,
    name: 'Slägga',
    price: 1095,
  },
  {
    id: 2,
    name: 'Sliprondell',
    price: 11.95,
  },
  {
    id: 3,
    name: 'Hammare',
    price: 495,
  },
];

// Skapa en Endpoint för get anrop...
// http://localhost:5001/api/products...
app.get('/api/products', (req, res) => {
  res.status(200).json({ success: true, data: products });
});

// Starta servern och lyssna på anrop via port 5001...
app.listen(5001, () =>
  console.log('Server är startad och lyssnar på porten 5001')
);
