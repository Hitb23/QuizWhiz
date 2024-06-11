import React from "react";
import AuthHeader from "../components/headers/AuthHeader";
import classes from "./ResetPasswordPage.module.css";
import { Link } from "react-router-dom";

const ResetPasswordPage = () => {
  return (
    <React.Fragment>
      <AuthHeader />
      <main className={`${classes.mainComponent} container-fluid`}>
        <div className={`row justify-content-center`}>
          <div
            className={`${classes.resetPasswordTitle} col-md-6 col-sm-8 col-10 text-center fw-bold`}
          >
            Reset Password
          </div>
          <div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-xl-4 col-md-6 col-sm-8 col-10 pt-3 pb-3">
                <label htmlFor="password" className="form-label fw-bold">
                  Password
                </label>
                <input
                  type="password"
                  className={`${classes.formInput} form-control form-control-md p-3`}
                  id="password"
                  placeholder="Password"
                />
              </div>
            </div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-xl-4 col-md-6 col-sm-8 col-10 pt-3 pb-3">
                <label htmlFor="confirmpassword" className="form-label fw-bold">
                  Confirm Password
                </label>
                <input
                  type="password"
                  className={`${classes.formInput} form-control form-control-md p-3`}
                  id="confirmpassword"
                  placeholder="Password"
                />
              </div>
            </div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-xl-4 col-md-6 col-sm-8 col-10 pt-3 pb-3 d-flex justify-content-center">
                <button className={classes.resetPasswordButton}>
                  Reset Password
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

export default ResetPasswordPage;
