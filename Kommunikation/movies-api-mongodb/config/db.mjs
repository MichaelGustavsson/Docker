import mongoose from 'mongoose';

const connectDb = async () => {
  const conn = await mongoose.connect('mongodb://???:27017/movies');
  if (conn) {
    console.log(`Connected to ${conn.connection.host}`);
  }
};

export default connectDb;
