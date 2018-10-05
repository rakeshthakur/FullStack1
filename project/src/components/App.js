import React from "react";

import Header from "./Header";
import Nav from "./Nav";
import Content from "./Content";

class App extends React.Component {
  render() {
    return (
      <main className="main">
        <Header />
        <Nav />
        <Content />
      </main>
    );
  }
}

export default App;
