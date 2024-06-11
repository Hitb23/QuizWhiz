import React from "react";
import logo from "../assets/logo.svg";
import classes from "./LandingHeader.module.css";
import { Link } from "react-router-dom";

const LandingHeader = () => {
  return (
    <React.Fragment>
      <div className={classes.header}>
        <div className={classes.logoDiv}>
          <Link to="/">
            <img
              className={`img-responsive ${classes.webLogo}`}
              src={logo}
              alt="logo"
            />
          </Link>
        </div>
        <div className={classes.headerButtons}>
          <button className={classes.signUpButton}>Sign Up</button>
          <button className={classes.logInButton}>Log In</button>
        </div>
      </div>
    </React.Fragment>
  );
};

export default LandingHeader;
