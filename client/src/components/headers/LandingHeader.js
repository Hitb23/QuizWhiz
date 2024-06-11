import React from "react";
import { Logo } from "../../assets";
import classes from "./LandingHeader.module.css";
import { Link } from "react-router-dom";

const LandingHeader = () => {
  return (
    <React.Fragment>
      <header className={classes.header}>
        <div className={classes.logoDiv}>
          <Link to="/">
            <img
              className={`img-responsive ${classes.webLogo}`}
              src={Logo}
              alt="logo"
            />
          </Link>
        </div>
        <div className={classes.headerButtons}>
          <Link to="/sign-up">
            <button className={classes.signUpButton}>Sign Up</button>
          </Link>
          <Link to="/login">
            <button className={classes.logInButton}>Log In</button>
          </Link>
        </div>
      </header>
    </React.Fragment>
  );
};

export default LandingHeader;
