import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import LandingHeader from '../components/LandingHeader';

function WelcomePage() {
  return (
    <React.Fragment>
      <LandingHeader />
      <p className='text-primary'>Welcome</p>
    </React.Fragment>
  )
}

export default WelcomePage
