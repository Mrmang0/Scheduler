import React from "react";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

import { ThemeProvider } from "@material-ui/core";

import { Auth } from "./pages";
import { theme } from "./constants";
import { Provider } from "react-redux";
import store from "./redux/store";

function App() {
  return (
    <Provider store={store}>
      <ThemeProvider theme={theme}>
        <Router>
          <Switch>
            <Route exact path="/" component={Auth} />
            <Route exact path="/home" component={Auth} />
          </Switch>
        </Router>
      </ThemeProvider>
    </Provider>
  );
}

export default App;
