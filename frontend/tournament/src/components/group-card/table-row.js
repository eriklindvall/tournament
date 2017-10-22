import React, { Component } from 'react';

class TableRow extends Component {
  render() {
    return (
      <tr>
        <td>{this.props.name}</td>
        <td>{this.props.played}</td>
        <td>{this.props.wins}</td>
        <td>{this.props.draws}</td>
        <td>{this.props.losses}</td>
        <td>{this.props.goalsScored}-{this.props.goalsConceded}</td>
        <td>{this.props.points}</td>
      </tr>
    );
  }
}

export default TableRow;
