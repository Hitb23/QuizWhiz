import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import LandingHeader from "../components/headers/LandingHeader";
import LandingFooter from "../components/footers/LandingFooter";
import classes from "./WelcomePage.module.css";
import { WelcomePoster } from "../assets";
import { Button } from "bootstrap";
import { Link } from "react-router-dom";
 
function WelcomePage() {
  return (
    <React.Fragment>
      <LandingHeader />
      <main className={classes.mainComponent}>
        <div className={classes.welcomeMessage}>
          <div className={classes.welcomeTitle}>Welcome To QuizWhiz</div>
          <div className={classes.welcomeSlogan}>
            Where Every Game is a Brain Boost!
          </div>
        </div>
        <div className={classes.poster}>
          <img
            className={`img-responsive ${classes.posterImg}`}
            src={WelcomePoster}
            alt="logo"
          />
          <Link to="">
            <button className={classes.getStartedButton}>Get Started</button>
          </Link>
        </div>
      </main>
      <LandingFooter />
    </React.Fragment>
  );
}

export default WelcomePage;
