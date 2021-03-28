import React, { Component } from 'react';
import axios from 'axios';

export class CommitsDataGrid extends Component {

    constructor(props) {
        super(props);
        this.state = { commits: [], commitsLoading: true };

        console.log(this.props.history.location)
    }

    componentDidMount() {
        this.getUsersCommits()
    }

    static renderCommitsTable(commits) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>SHA</th>
                        <th>Commit Message</th>
                        <th>Commit Author Name</th>
                        <th>Commit Author Email</th>
                    </tr>
                </thead>
                <tbody>
                    {commits.map(commit =>
                        <tr key={commit.sha}>
                            <td>{commit.sha}</td>
                            <td>{commit.commit.message}</td>
                            <td>{commit.commit.author.name}</td>
                            <td>{commit.commit.author.email}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : CommitsDataGrid.renderCommitsTable(this.state.commits);

        return (
            <div>
                <h1 id="tabelLabel" >Last Ten commits for the selected repository</h1>
                <p>A maximum of 10 commits will be displayed.</p>
                {contents}
            </div>
        );
    }

    async getUsersCommits() {
        const response = await axios.post(`http://localhost:63190/api/git-hub/get-user-commits/${this.props.history.location.state.userName}/${this.props.history.location.state.token}?limit=10`, { uri: this.props.history.location.state.uri, repository: this.props.history.location.state.repo })
        const data = response.data;
        this.setState({ commits: data, commitsLoading: false });
    }
}