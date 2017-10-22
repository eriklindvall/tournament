import React, { Component } from 'react';
import GroupCard from '../components/group-card/group-card.js'

class Results extends Component {
  constructor(props) {
    super(props);

    this.state = {
      tables : []
    };
  }

  render() {
    const groups = this.state.tables.map(group =>
    <GroupCard name={group.GroupName} table={group.Table} matches={group.Matches} />);
    return (
      <div className="Results">
        {groups}
      </div>
    );
  }

  componentDidMount() {
    fetch('/api/group/result')
    .then(response => response.json())
    .then(data => this.setState({tables : data}));
  }
}

export default Results;
