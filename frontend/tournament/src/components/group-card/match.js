import React, { Component } from 'react';

class Match extends Component {
  render() {
    return (
      <li>
        {this.props.kickoffTime}<br/>
        {this.props.homeTeam}-{this.props.awayTeam} {this.props.homeScore}-{this.props.awayScore}
      </li>
    );
  }
}

export default Match;
