import './App.css';
import { getTestMessage } from './Services/apiServices';
import {useEffect,useState} from 'react';

const App = () => {
  const [message, setMessage] = useState('');

  useEffect(() => {
      const fetchMessage = async () => {
          try {
              const data = await getTestMessage();
              setMessage(data.message);
          } catch (error) {
              console.error('Error fetching message', error);
          }
      };

      fetchMessage();
  }, []);

  return (
      <div>
          <h1>Message from Backend</h1>
          <p>{message}</p>
      </div>
  );
};

export default App;
