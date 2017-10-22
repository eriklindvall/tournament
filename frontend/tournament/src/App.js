import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import Menu from './components/menu/menu.js'
import Results from './containers/results.js'

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React Erik</h1>
        </header>
        <Menu />
        <Results />
      </div>
    );
  }
}

export default App;
