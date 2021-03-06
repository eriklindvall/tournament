import React, { Component } from 'react';
import './menu.css'

class Menu extends Component {
  render() {
    return (
      <div className="Menu">
        <nav>
          <a href="/" className="active">Tournament results</a>
          <a href="/">My bets</a>
          <a href="/">Ranking</a>
          <a href="/">Participants</a>
          <a href="/">Admin</a>
        </nav>
        <hr />
      </div>
    );
  }
}

export default Menu;
