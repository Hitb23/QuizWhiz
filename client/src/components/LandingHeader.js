import React from 'react';
import logo from '../assets/logo.svg';
import classes from './LandingHeader.module.css';

function LandingHeader() {
  return (
    <>
    <div className={classes.header}>
      <div className={classes.logoDiv}>
        <img className={`img-responsive ${classes.webLogo}`} src={logo} alt='logo'/>
      </div>
      <div className={classes.headerButtons}>
        <button className={classes.signUpButton} >Sign Up</button>
        <button className={classes.logInButton}>Log In</button>
      </div>
    </div>
      
    </>
  )
}

export default LandingHeader
