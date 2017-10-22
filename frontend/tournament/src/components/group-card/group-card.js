import React, { Component } from 'react';
import TableRow from './table-row.js';
import Match from './match.js';

class GroupCard extends Component {
  render() {
    return (
      <div className="GroupCard">
        <table>
          <tr>
            <th>{this.props.name}</th>
          </tr>
          {this.props.table.map(row => <TableRow
            name={row.Team.Name}
            played={row.Played}
            wins={row.Wins}
            draws={row.Draws}
            losses={row.Losses}
            goalsScored={row.GoalsScored}
            goalsConceded={row.GoalsConceded}
            points={row.Points} />)}
        </table>
        <h5>Matches</h5>
        <ul>
          {this.props.matches.map(match => <Match
            homeTeam={match.HomeTeam.Name}
            awayTeam={match.AwayTeam.Name}
            homeScore={match.HomeScore}
            awayScore={match.AwayScore}
            kickoffTime={match.KickoffTime}/>)}
        </ul>



        <hr />
      </div>
    );
  }
}

export default GroupCard;
