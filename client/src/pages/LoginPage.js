import React from "react";
import AuthHeader from "../components/headers/AuthHeader";
import classes from "./LoginPage.module.css";
import { Link } from "react-router-dom";

const LoginPage = () => {
  return (
    <React.Fragment>
      <AuthHeader />
      <main className={`${classes.mainComponent} container-fluid`}>
        <div className={`${classes.loginDiv} row justify-content-center`}>
          <div
            className={`${classes.logInTitle} col-md-6 col-sm-8 col-10 text-center fw-bold`}
          >
            Log In
          </div>
          <div className="">
            <div className={`d-flex justify-content-center`}>
              <div className="col-md-6 col-sm-8 col-10 pt-3 pb-3">
                <label for="email" class="form-label fw-bold">
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
              <div className="col-md-6 col-sm-8 col-10 pt-3 pb-3">
                <label for="password" class="form-label fw-bold">
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
              <div className="col-md-6 col-sm-8 col-10 pt-3 pb-3 d-flex flex-row-reverse">
                <Link to="/forgot-password">
                  <label
                    for="email"
                    className={`form-label fw-bold text-end text-decoration-none text-black pe-auto ${classes.forgotPasswordLabel}`}
                  >
                    Forgot Password?
                  </label>
                </Link>
              </div>
            </div>
            <div className={`d-flex justify-content-center`}>
              <div className="col-md-6 col-sm-8 col-10 pt-3 pb-3 d-flex justify-content-center">
                <button className={classes.logInButton}>Log In</button>
              </div>
            </div>
            <div className={`d-flex justify-content-center`}>
              <div class="col-md-6 col-sm-8 col-10 pt-3 pb-3 d-flex justify-content-center column-gap-2 flex-wrap">
                <div className="d-flex align-items-center">Don't you have an account?</div>
                <Link to="/sign-up">
                  <label
                    for="email"
                    className={`form-label fw-bold text-end text-decoration-none m-0 text-black pe-auto ${classes.forgotPasswordLabel}`}
                  >
                    Sign Up
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

export default LoginPage;
