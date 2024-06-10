import './App.css';
import { getTestMessage } from './services/apiServices';
import {useEffect,useState} from 'react';
import WelcomePage from './pages/WelcomePage';

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
          <WelcomePage />
          {message}
      </div>
  );
};

export default App;
