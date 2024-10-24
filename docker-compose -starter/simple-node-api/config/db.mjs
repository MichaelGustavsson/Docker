import mongoose from 'mongoose';

const connectDb = async () => {
  const conn = await mongoose.connect(
    'mongodb://host.docker.internal:27017/carpark'
  );

  if (conn) {
    console.log(`Connected to ${conn.connection.host}`);
  } else {
    console.log('Connection failed');
  }
};

export default connectDb;
