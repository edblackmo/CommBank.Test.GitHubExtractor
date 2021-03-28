import React, { Component } from 'react';
import { Route } from 'react-router-dom';
import axios from 'axios';

export class FetchData extends Component {
    static displayName = FetchData.name;
    static currentProps = null;

    constructor(props) {
        super(props);
        this.state = { repos: [], loading: true };
        FetchData.currentProps = props;
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
                            <td> <Route render={({ history }) => (
                                <button
                                    type='button'
                                    onClick={() => {
                                        history.push({
                                            pathname: '/fetch-data/commits',
                                            state: { uri: FetchData.currentProps.history.location.state.uri, userName: FetchData.currentProps.history.location.state.userName, token: FetchData.currentProps.history.location.state.token, repo: repo.fullName }
                                        })
                                    }}
                                >
                                   Click to Retrieve Commits
                                </button>
                            )} /></td>
                            <td>
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
                <h1 id="tabelLabel" >Public Repositories for User</h1>  
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await axios.post(`http://localhost:63190/api/git-hub/get-user-repositories/${this.props.history.location.state.userName}/${this.props.history.location.state.token}`, { "uri": this.props.history.location.state.uri });
        const data = response.data;
        this.setState({ repos: data, loading: false });
    }
}

