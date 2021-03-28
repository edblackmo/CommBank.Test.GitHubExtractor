import React, { Component } from 'react';
import axios from 'axios';

export class FetchData extends Component {
    static displayName = FetchData.name;

    static handleRowClick(e) {
        // FetchData.getUsersCommits(e.target.innerText);
    }

    constructor(props) {
        super(props);
        this.state = { repos: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(repos) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Click to see user's commits</th>
                        <th>Full Name</th>
                        <th>Owner</th>
                        <th>Login</th>
                        <th>Url</th>
                    </tr>
                </thead>
                <tbody>
                    {repos.map(repo =>
                        <tr key={repo.fullName}>
                            <td onClick={FetchData.handleRowClick}>
                                {repo.fullName}
                            </td>
                            <td>{repo.owner.login}</td>
                            <td>{repo.owner.url}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.repos);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await axios.post("http://localhost:63190/api/git-hub/get-user-repositories/edblackmo/6a507c8cec634e4783404089b464143407085a5e", { "uri": "https://api.github.com" })
        const data = response.data;
        this.setState({ repos: data, loading: false });
    }   
}

