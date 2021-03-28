import React, { Component } from 'react';
import axios from 'axios';

export class CommitsDataGrid extends Component {

    constructor(props) {
        super(props);
        this.state = { commits: [], commitsLoading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
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
                            <td>{commit.message}</td>
                            <td>{commit.author.name}</td>
                            <td>{commit.author.email}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderCommitsTable(this.state.commits);

        return (
            <div>
                <h1 id="tabelLabel" >Last Ten commits for the selected repository</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async getUsersCommits() {
        const response = await axios.post(`http://localhost:63190/api/git-hub/get-user-commits/${this.props.userName}/${this.props.token}`, { "uri": `"${this.props.uri}"`, "repository": `"${this.props.repository}"` })
        const data = response.data;
        this.setState({ commits: data, commitsLoading: false });
    }
}