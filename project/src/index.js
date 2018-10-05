import React from "react";
import ReactDOM from "react-dom";
import { createStore } from "redux";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import { composeWithDevTools } from "redux-devtools-extension";

import "./styles.css";

import App from "./components/App";
import loginReducer from "./reducers/loginReducer";

const spaStore = createStore(loginReducer, composeWithDevTools());

ReactDOM.render(
  <Provider store={spaStore}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById("app"),
);
