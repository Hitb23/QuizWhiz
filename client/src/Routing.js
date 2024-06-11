import React from "react";
import { Routes, Route } from 'react-router-dom';
import WelcomePage from "./pages/WelcomePage";
import LoginPage from "./pages/LoginPage";
import SignUpPage from "./pages/SignUpPage";

const Routing = () => {
  return(
    <React.Fragment>
      <Routes>
        <Route exact path="/" element={<WelcomePage />} />
        <Route exact path="/login" element={<LoginPage />} />
        <Route exact path="/sign-up" element={<SignUpPage />} />
      </Routes>
    </React.Fragment>
  );
}

export default Routing;