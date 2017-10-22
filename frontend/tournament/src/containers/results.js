import React, { Component } from 'react';

class Results extends Component {
  constructor(props) {
    super(props);

    this.state = {
      tables : []
    };
  }

  render() {
    const groups = this.state.tables.map(group =>
    <div></div>);
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
