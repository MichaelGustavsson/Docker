import mongoose, { Schema } from 'mongoose';

const vehicleSchema = new Schema({
  manufacturer: String,
  model: String,
});

const Model = mongoose.model('Vehicle', vehicleSchema);
export default Model;
