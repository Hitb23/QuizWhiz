import React from "react";
import AuthHeader from "../components/headers/AuthHeader";
import classes from "./ForgotPasswordPage.module.css";
import { Link } from "react-router-dom";

const ForgotPasswordPage = () => {
  return (
    <React.Fragment>
      <AuthHeader />
      <main className={`${classes.mainComponent} container-fluid`}>
        <div className={`row justify-content-center`}>
          <div
            className={`${classes.forgotPasswordTitle} col-md-6 col-sm-8 col-10 text-center fw-bold`}
          >
            Forgot Password?
          </div>
          <div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-xl-4 col-md-6 col-sm-8 col-10 pt-5 pb-5">
                <label htmlFor="email" className="form-label fw-bold">
                  Email Address
                </label>
                <input
                  type="email"
                  className={`${classes.formInput} form-control form-control-md p-3`}
                  id="email"
                  placeholder="name@example.com"
                  autoComplete="off"
                />
              </div>
            </div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-xl-4 col-md-6 col-sm-8 col-10 pt-3 pb-3 d-flex justify-content-center">
                <button className={classes.forgotPasswordButton}>
                  Send Email Link
                </button>
              </div>
            </div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-xl-4 col-md-6 col-sm-8 col-10 pt-3 pb-3 d-flex justify-content-center column-gap-2 flex-wrap">
                <Link to="/login">
                  <label
                    className={`form-label fw-bold text-end text-decoration-none m-0 text-black pe-auto ${classes.backToLoginLabel}`}
                  >
                    &lt; Back To Login
                  </label>
                </Link>
              </div>
            </div>
          </div>
        </div>
      </main>
    </React.Fragment>
  );
};

export default ForgotPasswordPage;
