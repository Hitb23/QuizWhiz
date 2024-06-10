import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import LandingHeader from '../components/LandingHeader';

function WelcomePage() {
  return (
    <>
      <LandingHeader />
      <p className='text-primary'>Welcome</p>
    </>
  )
}

export default WelcomePage
