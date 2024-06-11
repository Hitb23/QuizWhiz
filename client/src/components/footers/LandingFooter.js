import React from "react";
import classes from "./LandingFooter.module.css";
import { Link } from "react-router-dom";
import { Facebook, LinkedIn, Instagram, Youtube } from "../../assets";

const LandingFooter = () => {
  return (
    <React.Fragment>
      <footer className={classes.footer}>
        <div className={classes.logoDiv}>
          <Link to="/" className={classes.nameLink}>
            <div className={classes.companyName}>QuizWhiz</div>
          </Link>
        </div>
        <div className={classes.socialMediaIcons}>
          <Link to="">
            <img
              className={`img-responsive ${classes.socialMediaIcon}`}
              src={Facebook}
              alt="Facebook"
            />
          </Link>
          <Link to="">
            <img
              className={`img-responsive ${classes.socialMediaIcon}`}
              src={LinkedIn}
              alt="LinkedIn"
            />
          </Link>
          <Link to="">
            <img
              className={`img-responsive ${classes.socialMediaIcon}`}
              src={Youtube}
              alt="Youtube"
            />
          </Link>
          <Link to="">
            <img
              className={`img-responsive ${classes.socialMediaIcon}`}
              src={Instagram}
              alt="Instagram"
            />
          </Link>
        </div>
      </footer>
    </React.Fragment>
  );
};

export default LandingFooter;
