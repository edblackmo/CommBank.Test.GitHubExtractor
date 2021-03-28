import React, { Component } from 'react';
import { Route } from 'react-router-dom';

export class Home extends Component {
    static displayName = Home.name;
  
    constructor(props) {
        super(props);
        this.state = { uriValue: '', userNameValue: '', tokenValue: '' };
        this.handleUriChange = this.handleUriChange.bind(this);
        this.handleUserNameChange = this.handleUserNameChange.bind(this);
        this.handleTokenChange = this.handleTokenChange.bind(this);          
    }

    handleUriChange(event) {       
        this.setState({ uriValue: event.target.value });
    }

    handleUserNameChange(event) {
        this.setState({ userNameValue: event.target.value });
    }

    handleTokenChange(event) {
        this.setState({ tokenValue: event.target.value });
    }  

    //TODO: Formik with yup validation 
    render() {
        return (
            <div>
                <h1>Git Hub Repositories</h1>
                <p>USe this page to get publi github repositories for a given user. All fields must be filled in!</p>

                <table>
                    <tr>
                        <td><label>Uri: </label></td>
                        <td> <input type={"text"} value={this.state.uriValue} onChange={this.handleUriChange} /></td>
                    </tr>
                    <tr>
                        <td><label>User Name: </label></td>
                        <td><input type={"text"} value={this.state.userNameValue} onChange={this.handleUserNameChange} /></td>
                    </tr>
                    <tr>
                        <td><label>Token: </label></td>
                        <td><input type={"text"} value={this.state.tokenValue} onChange={this.handleTokenChange} /></td>
                    </tr>
                </table>
                <Route render={({ history }) => (
                    <button
                        type='button'
                        onClick={() => { history.push({ pathname: '/fetch-data', state: { uri: this.state.uriValue, userName: this.state.userNameValue, token: this.state.tokenValue } }) }}
                    >
                        Submit
                    </button>
                )} />
            </div>
        );
    }
}
