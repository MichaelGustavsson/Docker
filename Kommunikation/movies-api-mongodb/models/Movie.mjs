import mongoose from 'mongoose';

const MovieSchema = new mongoose.Schema({
  name: String,
  imageUrl: String,
});

export default mongoose.model('Movie', MovieSchema);
